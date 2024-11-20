open System

// Funkcja do znajdowania najdłuższego słowa
let najdluzszeSlowo (tekst: string) =
    tekst.Split([| ' ' |], StringSplitOptions.RemoveEmptyEntries) //podział na tabele słów
    |> Array.maxBy (fun x -> x.Length) //wybranie najdłurzszego słowa

[<EntryPoint>]
let main argv =
    // Pobieranie tekstu od użytkownika
    printfn "Podaj tekst:"
    let tekst = Console.ReadLine()

    // Znajdowanie najdłuższego słowa
    let slowo = najdluzszeSlowo tekst
    let dlugosc = slowo.Length

    printfn "Najdłuższe słowo to: %s i jego długość to %d" slowo dlugosc
    0     // Zakończenie programu
