open System
open System.Collections.Generic

// Definicja listy łączonej
type LinkedList<'T> =
    | Empty // Pusta lista
    | Node of 'T * LinkedList<'T> // Węzeł zawierający wartość i referencję do następnego elementu

// Funkcja wyświetlająca elementy listy
let rec printList list =
    match list with
    | Empty -> ()
    | Node(value, next) ->
        printf "%A " value
        printList next



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
        value + sumList next //sumoje wartości wywołując rekuręcyjnie siebie
// Przykład użycia
[<EntryPoint>]
let main argv =
    //zad 1
    let Lista = [1; 2; 3; 4; 5]
    let linkedList= fromList Lista
    printList linkedList

    //zad2
    let sum=sumList linkedList
    printf"suma listy łączonej to: %i " sum
    System.Console.ReadLine()

    0