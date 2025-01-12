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

let rec fromList lst =
    match lst with 
    | [] -> Empty
    | head :: tail -> Node(head, fromList tail)
 

//zadanie 5 Napisz funkcję, która sprawdza, czy dany element znajduje się w liście.
let rec findInList element list  =
    match list with
    | Empty -> false
    | Node(value, next) ->
        if value = element then true
        else findInList element next

[<EntryPoint>]
let main argv =

    let Lista = [1; 2; 3; 4; 5]
    let linkedList= fromList Lista
    printList linkedList

//zad5
    let element=5
    let found= findInList element linkedList
    printf"\nczy %i jest w liście? %b" element found

    let element=9
    let found= findInList element linkedList
    printf"\nczy %i jest w liście? %b" element found

    System.Console.ReadLine()

    0