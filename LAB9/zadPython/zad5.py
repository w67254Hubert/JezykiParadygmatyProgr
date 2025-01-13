# Stwórz klasę Prostokat z polami długość i szerokość. Dodaj metody do obliczania pola i obwodu.
class Prostokont:
    def __init__(self,dlugosc,szerokosc):
        self.dlugosc=dlugosc
        self.szerokosc= szerokosc
    def obliczpole(self):
       return self.dlugosc*self.szerokosc
    def obliczObwod(self):
        return self.dlugosc*2+ 2**self.szerokosc


prost=Prostokont(2,4)
print("obwód wynosi ", prost.obliczObwod)
print("pole wynosi ",prost.obliczpole)