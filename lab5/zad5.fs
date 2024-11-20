module zad2
open System
//przerobiony kod z python działa

let partition (array: int[]) low high =
    let pivot = array.[high]
    let mutable i = low - 1

    for j in low .. high - 1 do
        if array.[j] <= pivot then
            i <- i + 1
            // Swap
            let temp = array.[i]
            array.[i] <- array.[j]
            array.[j] <- temp

    // Swap pivot to correct position
    let temp = array.[i + 1]
    array.[i + 1] <- array.[high]
    array.[high] <- temp
    i + 1

let rec quicksort (array: int[]) (low: int) (high: int) =
    if low < high then
        let pivotIndex = partition array low high
        quicksort array low (pivotIndex - 1)
        quicksort array (pivotIndex + 1) high

// Testowanie algorytmu QuickSort
let myArray = [|64; 34; 25; 12; 22; 11; 90; 5|]
quicksort myArray 0 (myArray.Length - 1)
printfn "Posortowana tablica: %A" myArray


let tekst = Console.ReadLine()