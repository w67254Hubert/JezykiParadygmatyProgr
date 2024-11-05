# klasy abstrakcyjna

from abc import ABC,abstractmethod

class zwierze(ABC):
    @abstractmethod
    def dzwiek(self):
        pass

class Kot(zwierze):
    def dzwiek(self):
        return "mial"

class Pies(zwierze):
    def dzwiek(self):
        return "hal"

#potem tworzysz klasy kot pies
#i odwolujesz się do funkcji w niech zawartych
