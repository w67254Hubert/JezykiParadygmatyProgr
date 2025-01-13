// Zaimplementuj algorytm znajdowania największego wspólnego dzielnika (NWD) dwóch liczb.
let rec gcd a b =
    if b = 0 then a
    else gcd b (a % b)

// Example usage
let num1 = 56
let num2 = 98
let result = gcd num1 num2
printfn "Największy wspólny dzielnik (NWD) liczb %d i %d to: %d" num1 num2 result
System.Console.ReadLine()