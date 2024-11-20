//Zadanie 2. Sprawdzenie palindromu
//Stwórz funkcję, która sprawdza, czy podany ciąg znaków jest palindromem (czytany od przodu i od tyłu
//jest taki sam). Program powinien pobierać tekst od użytkownika i wyświetlać odpowiedni komunikat.

module zad2
open System

let czyPalindrom (tekst: string) =
    let czystyTekst = tekst.ToLower()
    let odwTekst = new string(Array.rev(czystyTekst.ToCharArray()))
    if  odwTekst = czystyTekst then
        printfn "Podany tekst jest palindromem."
    else
        printfn "Podany tekst nie jest palindromem."

// Pobranie tekstu od użytkownika
printf "Podaj tekst: "
let tekst = Console.ReadLine()
czyPalindrom tekst

