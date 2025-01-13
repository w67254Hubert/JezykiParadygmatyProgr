// // Przykład funkcji iteracyjnej (sumowanie liczb od 1 do n):
iteracyjnie 
let sumIter n =
let mutable sum = 0
for i in 1 .. n do
sum <- sum + i
sum

// Przykład funkcji rekurencyjnej (sumowanie liczb od 1 do n):
//rekurencja

let rec sumRec n=
    if n <=0 then 0
    else n+ sumRec(n-1)

sumrec
//rekurencyjna suma ogonowa

let sumaTail n=
    let rec sumRecTal n acc =
        if n <=0 then acc
        else sumRecTal(n-1) (acc + n)
    sumRecTal n 0


