module zadania

type User = {
    Weight: float
    Height: float
}
let KalkulujBMI(user: User) =
    let HeightMeters = user.Height / 100.0
    let bmi = user.Weight / (HeightMeters ** 2)
    bmi

let getBMICat bmi=
    match bmi with
    | x when x < 16.0 ->"niedowaga"
    | x when x <= 18.5 && x<24.99 ->"prawidłowa"
    | x when x > 25.0 ->"nadwaga"
    | _ ->"popsułeś licznenie"

[<EntryPoint>]
let main argv=
    printf "podaj wagę w kg"
    let wheightinput= Console.ReadLine()
    let wheightinputFloat=float wheightinput
    printf "podaj wzrost w m"
    let heightinput= Console.ReadLine()
    let floatheightinput= 0.0//=System.Double.Parse(heightinput)
    let floatheightinput=System.Double.TryParse(heightinput,floatheightinput)

    //sprawdź czy watrtości nie są zerem 
    if wheightinputFloat >0.0 && floatheightinput>0.0 then
        let user={Weight=wheightinputFloat;Height=floatheightinput}
        let bmi =KalkulujBMI user
        let category= getBMICat bmi

    else
        printf
    0