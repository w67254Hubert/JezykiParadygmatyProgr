
# zad1
def sumaCyfr(x,y):
    return x+y

x=int(input("podaj liczbę 1"))
y=int(input("podaj liczbę 2"))
suma=sumaCyfr(x,y)
print("suma wynosi ",suma)

# zad2
def dodawanie(x,y):
    return print("wynik dodawania ",x+y)
def odejmowanie(x,y):
    return print("wynik odejmowania ",x-y)
def mnorzenie(x,y):
    return print("wynik mnożenia ",x*y)
def dzielenie(x,y):
    if y>0:
        return print("wynik dzielenia ",x/y)
    else:
        print("nie dzielimy przez 0")

while True:
    print("jakie obliczenia chcesz wykonać")
    print("+ dodawanie")
    print("- odejmowanie")
    print("* mnożenie")
    print("/ dzielenie")
    print("by zakończyć działanie wpisz koniec")
    obl=input("podaj znak")
    if obl=="+":
        x=int(input("podaj liczbę 1"))
        y=int(input("podaj liczbę 2"))
        dodawanie(x,y)
    elif obl=="-":
        x=int(input("podaj liczbę 1"))
        y=int(input("podaj liczbę 2"))
        odejmowanie(x,y)
    elif obl=="*":
        x=int(input("podaj liczbę 1"))
        y=int(input("podaj liczbę 2"))
        mnorzenie(x,y)
    elif obl=="/":
        x=int(input("podaj liczbę 1"))
        y=int(input("podaj liczbę 2"))
        dzielenie(x,y)
    elif obl.lower()=="koniec":
        x=int(input("podaj liczbę 1"))
        y=int(input("podaj liczbę 2"))
        dzielenie(x,y)   
    else:
        print("niepoprawny wybór")