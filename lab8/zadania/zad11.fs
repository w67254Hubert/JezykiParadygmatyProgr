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

// Funkcja rekurencyjna obliczająca ilość elementów na liście
let rec numberElements =
    function
    | Empty -> 0
    | Node (_, Tail) -> numberElements Tail + 1

// Funkcja wyszukująca element na liście i dodające nowy element za nią
// element - poszukiwany element listy
// newElement - nowy element, który chcemy wstawić


let rec fromList lst =
    match lst with 
    | [] -> Empty
    | head :: tail -> Node(head, fromList tail)
    
let rec findInList element list  =
    match list with
    | Empty -> false
    | Node(value, next) ->
        if value = element then true
        else findInList element next

// zadanie 11: Napisz funkcję, która usuwa duplikaty z listy.
let removeDuplicates list =
    let rec aux seen list =
        match list with 
        | Empty -> Empty 
        | Node(value, next) ->
             if findInList value seen then 
                aux seen next 
             else 
                Node(value, aux (Node(value, seen)) next)
    aux Empty list
// Przykład użycia
[<EntryPoint>]
let main argv =
    let Lista = [1; 2; 10; 4; 5;10;1]
    let linkedList= fromList Lista
    printf "\n łączona lista 1: "
    printList linkedList

    let uniqueList = removeDuplicates linkedList 
    printf"\n usuń duplikaty\n"
    printList uniqueList
    System.Console.ReadLine() |> ignore

    0