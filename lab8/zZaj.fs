open System
open System.Collections.Generic

// Definicja listy łączonej
type LinkedList<'T> =
    | Empty // Pusta lista
    | Node of 'T * LinkedList<'T> // Węzeł zawierający wartość i referencję do następnego elementu

// Funkcje przydatne podczas wykonywania operacji na głowie i ogonie
let Head =
    function
    | Empty -> failwith "Nie można pobrać głowy z listy pustej"
    | Node(Head, _) -> Head

let Tail =
    function
    | Empty -> failwith "Nie można pobrać ogona z listy pustej"
    | Node(_, Tail) -> Tail

// Funkcja dodająca element na początek listy
let addHead value list =
    Node(value, list)

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
let rec addAfter element newElement =
    function
    | Empty -> failwith ("Nie znaleziono elementu: " + element.ToString())
    | Node (Head, Tail) ->
        if Head = element then
            Node(Head, Node (newElement, Tail))
        else
            Node(Head, addAfter element newElement Tail)

// Przykład użycia
[<EntryPoint>]
let main argv =
    let list1 = Empty
    let list2 = addHead 1 list1
    let list3 = addHead 2 list2
    let list4 = addHead 3 list3
    let ilosc = numberElements list4
    printList list4 // Wynik: 3 2 1
    printf "%d" ilosc
    