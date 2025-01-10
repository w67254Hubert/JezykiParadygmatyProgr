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
//zadanie 3 Napisz funkcję, która znajduje maksymalny i minimalny element w liście liczbowej.
let rec MinMaxList list =
    //aux rekutrncyjnie przechodzi przez liste łączoną zapisująć wartości min i max 
    let rec aux list (min, max) =
        match list with
        | Empty -> (min, max)
        | Node(value, next) ->
        //sprawdzanie walue czy jest wartością max lub min
            let newMin = if value < min then value else min
            let newMax = if value > max then value else max
            aux next (newMin, newMax)//ponowne wywołanie z listą i wartościami min max
    
    match list with
    | Empty -> failwith "List is empty"
    | Node(value, next) -> aux next (value, value)
    //po 1 przejściu wywołuje funkcje aux przypisując 1 value jako wejściowe


[<EntryPoint>]
let main argv =

    //zad 1
    let Lista = [1; 2; 3; 4; 5]
    let linkedList= fromList Lista
    printList linkedList

//zad3
    let Min, Max = MinMaxList linkedList
    printf"\n wartość minimalna to:%i maxsymalna to %i" Min Max

    System.Console.ReadLine()

    0