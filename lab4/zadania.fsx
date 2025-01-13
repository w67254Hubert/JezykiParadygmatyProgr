open System

type User = {
    Weight: float
    Height: float
}
let KalkulujBMI(user: User) =
    let HeightMeters = user.Height / 100.0
    let bmi = user.Weight / (HeightMeters ** 2)
    bmi

let getBMICat bmi =
    match bmi with 
    | x when x < 16.0 -> "niedowaga" 
    | x when x >= 16.0 && x <= 18.5 -> "niedowaga" 
    | x when x > 18.5 && x <= 24.99 -> "prawidłowa" 
    | x when x >= 25.0 && x <= 29.99 -> "nadwaga" 
    | x when x >= 30.0 -> "otyłość"
    | _ -> "popsułeś licznenie"

//let main (argv: 'a)=
printf "podaj wagę w kg"
let wheightinput= Console.ReadLine()
let wheightinputFloat=float wheightinput
printf "podaj wzrost w m"
let heightinput= Console.ReadLine()
let heightinputFloat=float heightinput


//sprawdź czy watrtości nie są zerem 
if wheightinputFloat >0.0 && heightinputFloat>0.0 then
    let user={Weight=wheightinputFloat;Height=heightinputFloat}
    let bmi =KalkulujBMI user
    let category= getBMICat bmi

    printfn "Twoje BMI wynosi: %.2f" bmi
    printfn "Kategoria BMI: %s" category
else
    printf "Wprowadzone dane są niepoprawne."

let List = [1;2;3;4;5]

0
//musiałem wyrzucić [<EntryPoint>] i funkcję main poniewarz nie jest ona obsługiwana w fsx

