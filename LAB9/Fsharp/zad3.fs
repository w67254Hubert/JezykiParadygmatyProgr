type uczen(imie: string) =
    let mutable oceny: list<int> = []
    
    member this.Imie = imie
    member this.Oceny
        with get() = oceny
        and set(value) = oceny <- value

    member this.dodajOcene(grade: int) =
        oceny <- grade :: oceny

    member this.Raport () =
        let srednia =
            if (List.length this.Oceny) > 0 then
                let dl = List.length this.Oceny
                let sum = List.sum this.Oceny
                float sum / float dl
            else 0.0

        printfn "Raport dla ucznia: %s" this.Imie
        printfn "Oceny: %A" this.Oceny
        printfn "Średnia ocen: %.2f" srednia



let student = uczen("Jan")
student.dodajOcene(5)
student.dodajOcene(4)
student.Raport()
printfn "Oceny dla %s: %A" student.Imie student.Oceny


System.Console.ReadLine()