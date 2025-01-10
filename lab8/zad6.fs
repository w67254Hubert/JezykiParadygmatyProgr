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
 



//zadanie 6 Napisz funkcję, która określi indeks podanego elementu, jeżeli element nie znajduje się na liście
//zwróć odpowiednią wartość (można wykorzystać unie z dyskryminatorem).

//jeśli nie znajdzie zwraca -1
let rec findIndex element list =
    let rec aux list element index =
        match list with 
        | Empty -> -1
        | Node(value, next) -> 
        if value = element then index 
        else 
            aux next element (index + 1)
    aux list element 0

[<EntryPoint>]
let main argv =

    let Lista = [1; 2; 3; 4; 5]
    let linkedList= fromList Lista
    printList linkedList

//zad5
    let element: int=5
    
    let index: int= findIndex element linkedList
    if index>=0 then
        printfn "\n element %i znajduje się na indeksie %i" element index 
        else
        printfn "Element %i nie znajduje się na liście" element
    

    let element=9
    let index: int= findIndex element linkedList
    if index>=0 then
        printfn "\n element %i znajduje się na indeksie %i" element index 
        else
        printfn "Element %i nie znajduje się na liście" element

    System.Console.ReadLine()|> ignore

    0