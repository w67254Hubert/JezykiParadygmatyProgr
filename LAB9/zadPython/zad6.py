
# Zaimplementuj klasę Samochod, która dziedziczy po klasie Pojazd, i dodaj metodę jazda.
class Pojazd:
    def __init__(self):
        pass

    def jazda(self):
        pass


class Samochod(Pojazd):
    def __init__(self, marka):
        self.marka = marka
    def jazda(self):
        print("Brum brum")


x = Samochod("Bf")
x.jazda()
print(f"Marka samochodu: {x.marka}")
