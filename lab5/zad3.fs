module zad3

let rec permutations list =
    match list with
    | [] -> [[]]
    | x::xs ->
        permutations xs
        |> List.collect (fun perm -> 
            [ for i in 0 .. List.length perm -> 
                let (left, right) = List.splitAt i perm
                left @ (x :: right) ]
        )

let resultPermutations = permutations [1; 2; 3]
printfn "Permutacje listy [1; 2; 3]:"
resultPermutations |> List.iter (printfn "%A")

let tekst = Console.ReadLine()