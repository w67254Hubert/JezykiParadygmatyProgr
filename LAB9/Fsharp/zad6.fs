let rec silnia n =
    if n <= 1 then 1
    else n * silnia (n - 1)

// Example usage
let num = 5
let wynik = silnia num
printfn "Factorial of %d is: %d" num wynik // Output should be: Factorial of 5 is: 120
System.Console.ReadLine()