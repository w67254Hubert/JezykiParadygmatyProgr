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
    
// zadanie 10:Napisz funkcję, która zwraca listę zawierającą tylko elementy spełniające określony warunek.
let rec filterList condition list = 
    match list with 
    | Empty -> Empty 
    | Node(value, next) -> 
        if condition value then 
            Node(value, filterList condition next) 
        else 
            filterList condition next

// Przykład użycia
[<EntryPoint>]
let main argv =
    let Lista = [1; 2; 10; 4; 5]
    let linkedList= fromList Lista
    printf "\n łączona lista 1: "
    printList linkedList

    let isEven n = n % 2 = 0 
    let filteredList = filterList isEven linkedList 
    printf "\n łączona lista po usunięciu liczb nieparzystych: \n"
    printList filteredList 

    System.Console.ReadLine() |> ignore

    0