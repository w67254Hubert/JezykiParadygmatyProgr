import numpy as np

def WalidujWykonaj(operacja, A, B=None):
    try:
        if B is not None:
            if 'dodaj' in operacja or 'mnoz' in operacja:
                # Sprawdzanie wymiarów
                if A.shape != B.shape and 'dodawanie' in operacja:
                    raise ValueError("operacja dodawanie nie wykonana zły wymiar macierzy")
                if A.shape[1] != B.shape[0] and 'mnozenie' in operacja:
                    raise ValueError("operacja mnorzenie nie wykonana zły wymiar macierzy")
                
        return Wykonaj(operacja)

    except Exception as e:
        return f"Błąd: {e}"

def Wykonaj(operacja):
    kod = f"""
wynik = None
if 'transponuj' in '{operacja}':
    wynik = np.transpose(A)
if 'dodawanie' in '{operacja}':
    wynik = A + B
if 'mnozenie' in '{operacja}':
    wynik = A @ B
"""
    exec(kod)#wykonanie kodu z string 
    return eval("wynik")#przechwycenie wartości wynik

# Przykładowe użycie
A = np.array([[2, 5], [6, 4]])
B = np.array([[1, 4], [1, 8]])

#wykonanie funkcji operacji na macierzach
print(WalidujWykonaj('dodawanie', A, B))       
print(WalidujWykonaj('mnozenie', A, B))      
print(WalidujWykonaj('transponuj', A))