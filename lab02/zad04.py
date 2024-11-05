import numpy as np
from functools import reduce

def polaczMacierze(macierze, operacja):
    # Funkcja pomocnicza do zastosowania operacji na dwóch macierzach
    def zastosujOperacje(a, b):
        
        return eval(f'a {operacja} b')

    # Łączenie macierzy za pomocą reduce()
    wynik = reduce(zastosujOperacje, macierze)
    return wynik

def transponujMacierze(macierze):
    # Funkcja pomocnicza do transponowania każdej macierzy
    return list(map(np.transpose, macierze))


# Przykładowe macierze
macierz1 = np.array([[1, 2], [3, 4]])
macierz2 = np.array([[5, 6], [7, 8]])
macierz3 = np.array([[9, 10], [11, 12]])

macierze = [macierz1, macierz2, macierz3]

# Przykładowe operacje
suma = '+'
iloczyn = '*'
odejmowanie = '-'

# Sumowanie macierzy
wynikSuma = polaczMacierze(macierze, suma)
print("Suma macierzy:")
print(wynikSuma)

# Mnożenie macierzy
wynikIloczyn = polaczMacierze(macierze, iloczyn)
print("\nIloczyn macierzy:")
print(wynikIloczyn)

# Odejmowanie macierzy
wynikOdejmowanie = polaczMacierze(macierze, odejmowanie)
print("\nOdejmowanie macierzy:")
print(wynikOdejmowanie)

# Transponowanie macierzy
wynikTransponowanie = transponujMacierze(macierze)
print("\nTransponowanie macierzy:")
for i, macierz in enumerate(wynikTransponowanie):
    print(f"Macierz {i+1}:\n{macierz}")
