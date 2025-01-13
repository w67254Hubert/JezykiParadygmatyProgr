// Napisz funkcję, która oblicza sumę liczb od 1 do n.
let rec sumarec n=
    if n=0 then 
        0
    else 
        n+sumarec (n-1)

let sumaIter n=
    let mutable sum=0
    for x in 1..n do
        sum<- sum+x
    sum
let suma=sumaIter 3
printf "suma %i" suma

let suma2=sumarec 3
printf "\nsuma %i" suma2

System.Console.ReadLine() |> ignore
