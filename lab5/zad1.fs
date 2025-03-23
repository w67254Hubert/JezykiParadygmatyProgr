module zad1

//Zadanie 1. Rekurencyjne generowanie ciągu Fibonacciego
//Napisz funkcję rekurencyjną, która oblicza n-ty wyraz ciągu Fibonacciego. Następnie zoptymalizuj ją,
//stosując funkcję z ogonową rekurencją

let rec fibonachi n=
    if n<=1 then n
    else fibonachi(n-1) + fibonachi(n-2)


let wynik = fibonachi 4
printf "rek fib z 4: %d" wynik

let fibTail n=
    let rec fibTailHelper  n acc=
        if n<=1 then n
        else fibTailHelper (n-2) + acc
    fibTailHelper  n 0

let sumaTail n=
    let rec sumRecTal n acc =
        if n <=0 then acc
        else sumRecTal(n-1) (acc + n)
    sumRecTal n 0
printf "\n"

let fib: int=sumaTail(5)
printf "wypisz mi dlafib = %d" fib
System.Console.ReadLine()



