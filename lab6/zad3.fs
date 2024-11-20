module zad3
open System
let usunDuplikaty (input: string) =
    input.Split(' ', StringSplitOptions.RemoveEmptyEntries)
    |> Seq.distinct //tworzy sekfencję unialnych słów
    |> Seq.toArray //zamiana sefencji na tabele

[<EntryPoint>]
let main argv =
    printfn "Podaj słowa oddzielone spacjami:"
    let tekst = Console.ReadLine()
    let wyjSlowa = usunDuplikaty tekst
    printfn "Lista unikalnych słów: %A" wyjSlowa

    let stopconsole = Console.ReadLine()
    0
