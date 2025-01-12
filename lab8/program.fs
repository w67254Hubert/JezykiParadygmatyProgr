open System
open System.Collections.Generic

// Definicja listy łączonej
type LinkedList<'T> =
    | Empty // Pusta lista
    | Node of 'T * LinkedList<'T> // Węzeł zawierający wartość i referencję do następnego elementu

// Funkcje przydatne podczas wykonywania operacji na głowie i ogonie
let Head =
    function
    | Empty -> failwith "Nie można pobrać głowy z listy pustej"
    | Node(Head, _) -> Head

let Tail =
    function
    | Empty -> failwith "Nie można pobrać ogona z listy pustej"
    | Node(_, Tail) -> Tail

// Funkcja dodająca element na początek listy
let addHead value list =
    Node(value, list)

// Funkcja wyświetlająca elementy listy
let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next

// Funkcja rekurencyjna obliczająca ilość elementów na liście
let rec numberElements =
    function
    | Empty -> 0
    | Node (_, Tail) -> numberElements Tail + 1

// Funkcja wyszukująca element na liście i dodające nowy element za nią
let rec addAfter element newElement =
    function
    | Empty -> failwith ("Nie znaleziono elementu: " + element.ToString())
    | Node (Head, Tail) ->
        if Head = element then
            Node(Head, Node (newElement, Tail))
        else
            Node(Head, addAfter element newElement Tail)

//zadanie 1 Napisz funkcję, która tworzy listę łączoną na podstawie zwykłej listy (List<'T>)
let rec fromList lst =
    match lst with 
    | [] -> Empty
    | head :: tail -> Node(head, fromList tail)

//zadanie 2 Napisz funkcję, która sumuje elementy listy zawierającej liczby całkowite.
let rec sumList list =
    match list with
    | Empty -> 0
    | Node(value, next) ->
        value + sumList next //sumuje wartości wywołując rekuręcyjnie siebie

//zadanie 3 Napisz funkcję, która znajduje maksymalny i minimalny element w liście liczbowej.
let rec MinMaxList list =
    //aux rekurncyjnie przechodzi przez liste łączoną zapisując wartości min i max 
    let rec aux list (min, max) =
        match list with
        | Empty -> (min, max)
        | Node(value, next) ->
        //sprawdzanie value czy jest wartością max lub min
            let newMin = if value < min then value else min
            let newMax = if value > max then value else max
            aux next (newMin, newMax)//ponowne wywołanie z listą i wartościami min max
    
    match list with
    | Empty -> failwith "List is empty"
    | Node(value, next) -> aux next (value, value)
    //po 1 przejściu wywołuje funkcje aux przypisując 1 value jako wejściowe

//zadanie 5 Napisz funkcję, która sprawdza, czy dany element znajduje się w liście.
let rec findInList element list  =
    match list with
    | Empty -> false
    | Node(value, next) ->
        if value = element then true
        else findInList element next


//zadanie 6 Napisz funkcję, która określi indeks podanego elementu, jeżeli element nie znajduje się na liście
//zwróć odpowiednią wartość (można wykorzystać unie z dyskryminatorem).
//jeśli nie znajdzie zwraca -1
let rec findIndex element list =
    let rec aux list element index =
        match list with 
        | Empty -> -1
        | Node(value, next) -> 
        if value = element then index 
        else 
            aux next element (index + 1)
    aux list element 0

//zadanie 7 Napisz funkcję, która zlicza, ile razy dany element występuje w liście.
let rec countRepets element list = 
    match list with 
    | Empty -> 0 
    | Node(value, next) ->
        let count = if value = element then 1 else 0
        count + countRepets element next

//zadanie 8 Napisz funkcję, która łączy dwie listy łączone w jedną.
let rec joinLists list1 list2 =
    match list1 with
    | Empty -> list2
    | Node(value, next) -> Node(value,joinLists next list2)

// zadanie 9: Napisz funkcję, która będzie przyjmowała dwie listy liczb całkowitych i zwracała listę wartości
// logicznych, gdzie true określa, że liczba na pierwszej liście była większa, a false, że wartość na
// drugiej liście była większa. Jeżeli jednia lista jest dłuższa od drugiej zwróć wyjątek informujący o tym
// fakcie.
let rec compareLists list1 list2 =
    let count1 = numberElements list1
    let count2 = numberElements list2 
    if count1 <> count2 then 
        failwith "Lists have unequal lengths"
    else
        let rec aux list1 list2=
            match (list1, list2) with
            | (Empty, Empty) -> Empty
            | (Node(x, next1), Node(y, next2)) ->
                let compare = x > y
                Node(compare, aux next1 next2)
            | _ -> failwith "Unexpected pattern"
        aux list1 list2

// zadanie 10: Napisz funkcję, która zwraca listę zawierającą tylko elementy spełniające określony warunek.
let rec filterList condition list = 
    match list with 
    | Empty -> Empty 
    | Node(value, next) -> 
        if condition value then 
            Node(value, filterList condition next) 
        else 
            filterList condition next

// zadanie 11: Napisz funkcję, która usuwa duplikaty z listy.
let removeDuplicates list =
    let rec aux seen list =
        match list with 
        | Empty -> Empty 
        | Node(value, next) ->
             if findInList value seen then 
                aux seen next 
             else 
                Node(value, aux (Node(value, seen)) next)
    aux Empty list

// główny program z menu konsolowym

[<EntryPoint>]
let main argv =
    let rec menu () =
        printfn "\nWybierz zadanie:"
        printfn "1. Utwórz listę łączoną na podstawie zwykłej listy"
        printfn "2. Sumuj elementy listy"
        printfn "3. Znajdź maksymalny i minimalny element w liście"
        printfn "5. Sprawdź, czy element znajduje się w liście"
        printfn "6. Znajdź indeks podanego elementu"
        printfn "7. Zlicz, ile razy element występuje w liście"
        printfn "8. Połącz dwie listy w jedną"
        printfn "9. Porównaj dwie listy liczb całkowitych"
        printfn "10. Zwróć listę z elementami spełniającymi określony warunek"
        printfn "11. Usuń duplikaty z listy"
        printfn "0. Wyjdź"

        let choice = Console.ReadLine()

        match choice with
        | "1" ->
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printf "Lista łączona: "
            printList linkedList
            printf "\n"
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "2" ->
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let sum = sumList linkedList
            printfn " Suma elementów listy: %i \n" sum
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "3" -> 
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let min, max = MinMaxList linkedList
            printfn "\n Min: %i, Max: %i" min max
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "5" -> 
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let element = 3
            let found = findInList element linkedList
            printfn "Czy element %i znajduje się w liście? %b" element found
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "6" ->
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let element = 3
            let index = findIndex element linkedList
            if index >= 0 then
                printfn "Element %i znajduje się na indeksie: %i" element index
            else
                printf "Element %i nie znajduje się na liście" element
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "7" ->
            let lista = [1; 2; 3; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let element = 3
            let count = countRepets element linkedList
            printfn "\n Element %i powtórzył się %i razy" element count
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "8" -> 
            let lista1 = [1; 2; 3; 4; 5]
            let linkedList1 = fromList lista1
            printList linkedList1
            printf "\n"
            let lista2 = [6; 7; 8; 9; 10]
            let linkedList2 = fromList lista2
            printList linkedList2
            printf "\n"
            let combinedList = joinLists linkedList1 linkedList2
            printf "Połączona lista: \n"
            printList combinedList
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "9" ->
            let lista1 = [1; 2; 10; 4; 5]
            let linkedList1 = fromList lista1
            printList linkedList1
            printf "\n"
            let lista2 = [6; 7; 2; 9; 1]
            let linkedList2 = fromList lista2
            printList linkedList2
            printf "\n"
            let comparisonList = compareLists linkedList1 linkedList2
            printf "Lista porównawcza: \n"
            printList comparisonList
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "10" ->
            let lista = [1; 2; 10; 4; 5]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let isEven n = n % 2 = 0
            let filteredList = filterList isEven linkedList
            printf "Lista z elementami spełniającymi warunek (parzyste):\n "
            printList filteredList
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "11" ->
            let lista = [1; 2; 10; 4; 5; 10; 1]
            let linkedList = fromList lista
            printList linkedList
            printf "\n"
            let uniqueList = removeDuplicates linkedList
            printf "Lista bez duplikatów: "
            printList uniqueList
            printf "\n Przyciśnij dowolny przycisk by przejść dalej \n"
            Console.ReadLine() |> ignore
            menu()
        | "0" ->
            printfn "Koniec programu."
        | _ ->
            printfn "Niepoprawny wybór, spróbuj ponownie."
            menu()

    //włączenie menu 
    menu()
    0
