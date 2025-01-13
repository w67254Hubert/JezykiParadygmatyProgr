// Używając funkcji List.map, zamień wszystkie litery w liście słów na wielkie litery.

let words: list<string> = ["hello"; "world"; "fsharp"]

let upperCaseWords = List.map (fun (s: string) -> s.ToUpper()) words

// Printing the result
printfn "Uppercase Words: %A" upperCaseWords
System.Console.ReadLine()