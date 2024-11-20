module zad4
open System

// Funkcja do  zmiany formatu tekstu
let strFormat (wpis: string) =
    let wartosci: string array = wpis.Split(';')//rozdzielanie wartości po ;
    if wartosci.Length = 3 then 
        let imie = wartosci.[0]
        let nazwisko = wartosci.[1]
        let wiek = wartosci.[2]
        sprintf "%s, %s (%s lat)" imie nazwisko wiek //zmienia wartość i ją zwraca
    else
        "Nieprawidłowye wartosci"

let zamienWpisy wpisy =
    wpisy
    |> Array.map strFormat //urzywa funkcji strFormat na karzdej wartości tablicy
    |> Array.iter (printfn "%s") //iteruje po tablicy i wypisuje wartości

// Główna funkcja programu
[<EntryPoint>]
let main argv =
    // Pobieranie wpisu od urzytkownika
    printfn "Podaj wpisy w formacie 'imię;nazwisko;wiek' (oddzielone przecinkami):"
    let input = Console.ReadLine()
    // Podział wpisów po przecinku i przypisanie ich do tablicy wpisy
    let wpisy: string array = input.Split([|','|], StringSplitOptions.RemoveEmptyEntries) 

    // wywołanie funkcji zmieniającej format
    zamienWpisy wpisy
    let input = Console.ReadLine() //tylko po to by się konsola nie zamykała
    // Zakończenie programu
    0 //dalej nie ogarniam czemu tu jest zero jako return?
    