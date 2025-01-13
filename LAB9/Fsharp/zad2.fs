// Utwórz program sprawdzający, czy liczba jest liczbą pierwszą. w f#
let czyPierwsza n =
    let rec czydzieli dzielnik =
        if dzielnik * dzielnik > n then true
        else if n % dzielnik = 0 then false
        else czydzieli (dzielnik + 1)
    if n <= 1 then false
    else czydzieli 2

let num = 7
let wynik = czyPierwsza num
printfn "Czy liczba %d jest liczbą pierwszą? %b" num wynik
