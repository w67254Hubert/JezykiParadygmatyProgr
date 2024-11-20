module zad2
open System
//definiowanie drzewa binarnego
type BinaryTree<'T> =
    | Empty
    | Node of 'T * BinaryTree<'T> * BinaryTree<'T>

//przykładowe drzewo binarne
let tree = Node(10, Node(5, Node(2 ,Empty,Empty), Empty), Node(15, Empty, Node(20, Empty, Node(25 ,Empty,Empty))))
let rec searchTree element tree =
    match tree with
    | Empty -> false
    | Node(value, left, right) ->
        if element = value then true
        else searchTree element left || searchTree element right

//definiowanie drzewa

let resultSearch = searchTree 15 tree //podanie wartości do finkcji

printfn "Czy 15 jest w drzewie? %b" resultSearch //wynik


let searchTreeIterative element tree =
    let rec loop stack =
        match stack with
        | [] -> false
        | Empty :: rest -> loop rest
        | Node(value, left, right) :: rest ->
            if element = value then true
            else loop (left :: right :: rest)
    loop [tree]

let resultSearchIter = searchTreeIterative 15 tree
printfn "Czy 15 jest w drzewie (iteracyjnie)? %b" resultSearchIter

//do zrozumienia na potem!!!!
let tekst = Console.ReadLine()