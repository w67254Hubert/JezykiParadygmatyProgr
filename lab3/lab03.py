# klasy abstrakcyjna

from abc import ABC,abstractmethod


class Smochodzik:
    def __init__(self, marka ,model,rok):
        self.__marka=marka #atrybut prywatny chroniony
        self._model=model #atrybut wewmętrrzny
        self.rok=rok #atrybut bubliczny

    def wypisz(self):
        return f'{self.marka}{self.model}{self.rok}' #nie będzie działać bo jest wartość "__" sekretna
        #i wartość tylko do odwołania w klasie "_"

class Pojazd(Smochodzik):#wielodziedziczenie czyli wiele klas można dać SamA, samB
    def __init__(self,marka,model,rok,a): #dziedziczenie potrzemujemy zmienne do dodania do klas obu
        super().__init__(marka,model,rok) #odwołanie do konstruktora klasy samochodzik i dajemy tam zmiene jej potrzebne
        self.a=a




wozik = Smochodzik("merc","klasa C" ,2000)
print(wozik.wypisz())
