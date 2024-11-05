// For more information see https://aka.ms/fsharp-console-apps
printfn "Hello from F#"


// czemu musze pisać dotnet run by uruchomić ten plik
//nie ma innego lepszego sposobu?

let x=5
let y="ala"
let mutable a = 14 //zmienna nie mutowalna
a<-a+1 //nie rób tego

printf "waertść liczby x = %d" x //za % definiujesz typ zmiennej do wypisania???
printf "\n twoje imie y = %s" y
printf "waertść liczby x = %d \n twoje imie y = %s" x y

printf "podaj imie: "
let name = System.Console.ReadLine() //czytanie znaków i przypidsanie ich do zmiennej
printf "podane imie %s" name

printf "podaj liczbe: "
let num = System.Console.ReadLine() //czytanie znaków i przypidsanie ich do zmiennej
let liczba = int num

printf "podane imie %d" liczba

//oeratory matematyczne logiczna itd

let v=22
let c=23

let mojeZapytanie =
    if v > c then 
        "v jest większy"
    else
        "c jest większy"

printf "%s" mojeZapytanie

let listaA=[1;2;3]//tworzenie listy

let listaB = 0:: listaA

for item in listaA do
    printf "%d " item

printf "\n"

for item in listaB do
    printf "%d " item

let listaC = listaA @ listaB
//łączenie listy listaA lista B
for item in listaC do //wyświetlenie elementów listy
    printf "%d " item

printf "\n"

printf "%A" listaC //%A dowolny typ wykorzystujący stringa (wyświetla całość)


//instacja rekordu
type Osoba = {
    imie: string
    wiek: int
}
let osoba1 = {imie="jan" ; wiek = 12}
let osoba2 = {imie="jan" ; wiek = 12}

printf "imie: %s Wiek: %d" osoba1.imie osoba1.wiek

printf "\n"

printf "%b" (osoba1=osoba2)

//definicja krotki
let krotka= (1,"ala",true)
