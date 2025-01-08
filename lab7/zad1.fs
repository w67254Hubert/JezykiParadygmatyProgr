
type Book(title: string, author: string, pages: int) =
    member this.Title = title
    member this.Author = author
    member this.Pages = pages
    member this.GetInfo() =
        sprintf "Tytuł: %s, Autor: %s, Liczba stron: %d" this.Title this.Author this.Pages

type User(name: string) =
    let mutable borrowedBooks: Book list = []
    member this.Name = name
    member this.BorrowedBooks = borrowedBooks

    member this.BorrowBook(book: Book) =
        borrowedBooks <- book :: borrowedBooks
        printfn "%s wypożyczył książkę: %s" this.Name book.Title

    member this.ReturnBook(book: Book) =
        if List.contains book borrowedBooks then
            borrowedBooks <- List.filter (fun (b: Book) -> b <> book) borrowedBooks
            printfn "%s zwrócił książkę: %s" this.Name book.Title
        else
            printfn "%s nie posiada książki: %s" this.Name book.Title

type Library() =
    let mutable books: Book list = []

    member this.AddBook(book: Book) =
        books <- book :: books
        printfn "Dodano książkę: %s" book.Title

    member this.RemoveBook(book: Book) =
        if List.contains book books then
            books <- List.filter (fun b -> b <> book) books
            printfn "Usunięto książkę: %s" book.Title
        else
            printfn "Książka: %s nie znajduje się w bibliotece" book.Title 

    member this.ListBooks() =
        if books.IsEmpty then
            printfn "Biblioteka nie ma książek." 
        else
            printfn "Książki w bibliotece:"
            for book in books do
                printfn "%s" (book.GetInfo())

[<EntryPoint>]
let main argv =
    //stworzenie obiektu liblary
    let library = Library()

    //tworzenie obiektów ksiąrzek
    let book1 = Book("Władca Pierścieni", "Tolkien", 1000)
    let book2 = Book("Harry Potter", "J.K. Rowling", 350)
    let book3 = Book("Krzyżacy", "Sienkiewicz", 400)

    // stworzenie urzytkownika użytkownika
    let user = User("Jan Kowalski")

    //dodanie ksiąrzek do library
    library.AddBook(book1)
    library.AddBook(book2)
    library.AddBook(book3)
    // wyświetlenie książek w library
    printfn "\n Aktualny stan biblioteki" 
    library.ListBooks()

    // porzyczanie książek przez user
    user.BorrowBook(book1)
    user.BorrowBook(book2)

    //lista ksążek posiadanych przez urzytkownika
    printfn "\n urzytkownik posiada książki:"
    for book in user.BorrowedBooks do
        printfn "%s" (book.GetInfo())

    // zwracanie książki przez user
    user.ReturnBook(book1)

    //lista ksążek posiadanych przez urzytkownika po oddaniu
    printfn "urzytkownik po oddaniu posiada książki:"
    for book in user.BorrowedBooks do
        printfn "%s" (book.GetInfo())

    // Wyświetlenie końcowego stanu książek library
    printfn "\n stan biblioteki po zwróceniu książki:" 
    library.ListBooks()

    System.Console.ReadLine()
    0 