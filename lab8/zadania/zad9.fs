open System
open System.Collections.Generic

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

//przekształcanie listy na listę łączoną 
let rec fromList lst =
    match lst with 
    | [] -> Empty
    | head :: tail -> Node(head, fromList tail)

// 9. Napisz funkcję, która będzie przyjmowała dwie listy liczb całkowitych i zwracała listę wartości
// logicznych, gdzie true określa, że liczba na pierwszej liście była większa, a false, że wartość na
// drugiej liście byłą większa. Jeżeli jednia lista jest dłużna od drugiej zwróć wyjątek informujący o tym
// fakcie.

let rec compareLists list1 list2 =
    let count1 = numberElements list1
    let count2 = numberElements list2 
    if count1 <> count2 then 
        failwith "Lists have unequal lengths"
    else
        let rec aux list1 list2=
            match (list1, list2) with
            | (Empty, Empty) -> Empty
            | (Node(x, nexst1), Node(y, nexst2)) ->
                let compare = x > y
                Node(compare, aux nexst1 nexst2)
            | _ -> failwith "Unexpected pattern"
        aux list1 list2


// Przykład użycia
[<EntryPoint>]
let main argv =
    let Lista = [1; 2; 10; 4; 5]
    let linkedList= fromList Lista
    printf "\n łączona lista 1: "
    printList linkedList
    let Lista2 = [6; 7; 2; 9; 1]
    let linkedList2= fromList Lista2
    printf "\n łączona lista 2: "
    printList linkedList2
    
    printf"\nlista list po porównaniu wartości list wieksze wartości oznaczone są:
    gdy True=lista1 False= lista2 posiada większą wartość \n"
    let listcomp=compareLists linkedList linkedList2
    printList listcomp
    System.Console.ReadLine() |> ignore


    0