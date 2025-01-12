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
    
    //zadanie 7 Napisz funkcję, która zlicza, ile razy dany element występuje w liście.
let rec countRepets element list = 
    match list with 
    | Empty -> 0 
    | Node(value, next) ->
        let count = if value = element then 1 else 0
        count + countRepets element next
// Przykład użycia
[<EntryPoint>]
let main argv =
    //zad 1
    let Lista = [1; 2; 3; 4; 5;3]
    let linkedList= fromList Lista
    printList linkedList

    //zad7
    let element =3
    let rep=countRepets element linkedList
    printf"\n numer %i powtóżył się %i " element rep

    System.Console.ReadLine() |> ignore

    0