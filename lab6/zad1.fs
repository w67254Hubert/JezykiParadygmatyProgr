module zad1

//Zadanie 1. Liczba słów i znaków
//Napisz program, który pobiera tekst od użytkownika, a następnie oblicza i wyświetla:
//• Liczbę słów w podanym tekście.
//• Liczbę znaków (bez spacji).
open System

let liczbaSlowIZnakow (tekst: string) =
    let slowaArr = tekst.Split([| ' ' ; '.'; ','; '\n'|], StringSplitOptions.RemoveEmptyEntries)
    let liczbaSlow = slowaArr.Length

    // Liczba znaków (bez spacji)
    let liczbaZnakow = tekst.Replace(" ", "").Length

    liczbaSlow, liczbaZnakow

// Pobranie tekstu od użytkownika
printf "Podaj tekst : "
let tekstUzytkownika = Console.ReadLine()
let slowa, znaki = liczbaSlowIZnakow tekstUzytkownika

printfn "Liczba słów: %d" slowa
printfn "Liczba znaków (bez spacji): %d" znaki
