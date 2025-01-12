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

// zadanie 8 Napisz funkcję, która łączy dwie listy łączone w jedną.
let rec joinLists list1 list2 =
    match list1 with
    | Empty -> list2
    | Node(value, next) -> Node(value,joinLists next list2)

// zamiana listy na listę łączoną 
let rec fromList lst =
    match lst with 
    | [] -> Empty
    | head :: tail -> Node(head, fromList tail)
    

// Przykład użycia
[<EntryPoint>]
let main argv =
    let Lista = [1; 2; 3; 4; 5]
    let linkedList= fromList Lista
    printf "\n łączona lista 1: "
    printList linkedList

    let Lista2 = [6; 7; 8; 9; 10]
    let linkedList2= fromList Lista2
    printf "\n łączona lista 2: "

    printList linkedList2
    let linkedList3=joinLists linkedList linkedList2
    printf "\n łączonie list 1 i 2: "

    printList linkedList3

    System.Console.ReadLine() |> ignore


    0