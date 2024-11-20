module zad4
open System
//działa jak w python tylko składnia inna

let rec hanoi n source target bonusOne =
    if n = 1 then
        printfn "Przenieś krążek z %s do %s" source target
    else
        hanoi (n - 1) source bonusOne target
        printfn "Przenieś krążek z %s do %s" source target
        hanoi (n - 1) bonusOne target source

// Wywołanie
hanoi 3 "A" "C" "B"


let tekst = Console.ReadLine()