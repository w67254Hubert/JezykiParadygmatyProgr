import csv
import heapq
from datetime import datetime, timedelta
import os

# Funkcja do odczytu danych z pliku CSV
def ReadCSV(scieszka):
    zadania = []
    with open(scieszka, mode='r') as plik:
        dane = csv.DictReader(plik)
        for rekord in dane:
            zad = {
                'id': int(rekord['id']),#id
                'nazwa': rekord['nazwa'],#nazwa zadania
                'deadline': datetime.strptime(rekord['deadline'], '%Y-%m-%d %H:%M:%S'), #dane do kiedy zrobić
                'czasTrwania': int(rekord['czasTrwania'])  # czas trwania zadania w minutach
            }
            zadania.append(zad)
    return zadania

# Funkcja do zapisywania wyników do pliku CSV
def zapHarmonogramDoCSV(harmonogram, outPlik):
    nazwyKolumn = ['id', 'nazwa', 'startZad', 'koniecZad', 'deadline', 'status']

    with open(outPlik, mode='w', newline='') as plik:
        zapis = csv.DictWriter(plik, fieldnames=nazwyKolumn)
        zapis.writeheader()
        for zad in harmonogram:
            zapis.writerow({
                'id': zad['id'],
                'nazwa': zad['nazwa'],
                 #strftime poprawne formatowanie daty do str
                'startZad': zad['startZad'].strftime('%Y-%m-%d %H:%M:%S'),
                'koniecZad': zad['koniecZad'].strftime('%Y-%m-%d %H:%M:%S'),
                'deadline': zad['deadline'].strftime('%Y-%m-%d %H:%M:%S'),
                'status': zad['status']
            })

# Implementacja algorytmu EDF
def edfHarmonogramr(zadania):

    PriorityQueue = []
    for zad in zadania: 
        #tworzenie kolejki pryjoretytowej gdzie priorytet zależy od bliskości dedline
        heapq.heappush(PriorityQueue, (zad['deadline'], zad))
        
    harmonogram = []
    czasTeraz = datetime.now() #tada czasu z pc np: 2025-01-06 14:35:22
    # czasTeraz = datetime(2025, 1, 6, 14, 35, 22) #dla testu "zatrzymanie czasu"

    while PriorityQueue:
        deadline, zad = heapq.heappop(PriorityQueue)  # Pobranie zadania z najbliższym deadline
        czasDelta=timedelta(minutes=zad['czasTrwania'])
        #sprawdza najpuźniejszy czas rozpoczęcia zadania jeśli czas jest wcześniejszy niż teraz to daje teraz
        if czasTeraz > zad['deadline'] - czasDelta :
            startZad = czasTeraz
        else:
            startZad = zad['deadline'] - czasDelta

        koniecZad = startZad + czasDelta
                

        if koniecZad <= zad['deadline']: 
            status = 'Na czas' 
        else: status = 'nie na czas' 

        harmonogram.append({
            'id': zad['id'],
            'nazwa': zad['nazwa'],
            'startZad': startZad,
            'koniecZad': koniecZad,
            'deadline': zad['deadline'],
            'status': status
        })

        czasTeraz = koniecZad

    return harmonogram

# Tworzenie pliku csv z zadaniami
def noweZadaniaDoCSV(scieszka):
    nazwyKolumn = ['id', 'nazwa', 'deadline', 'czasTrwania']
    plikIstnieje = os.path.exists(sciezka)
    #sprawdzanie czy istnieje i czy jest pusty i przybpisanie boola do zmiennej plikPusty
    plikPusty= not plikIstnieje or os.stat(sciezka).st_size == 0 
    
    with open(scieszka, mode='a', newline='') as plik:
        zapis = csv.DictWriter(plik, fieldnames=nazwyKolumn)

        if plikPusty: #kiedy pusty plik zapisz
            zapis.writeheader()
        zadID = 1
        #kiedy nie jest pusty zwiększ zadID wedlug ilości wierszy
        if not plikPusty: 
            with open(sciezka, mode='r') as plikDoOdczytu:
                odczyt = csv.DictReader(plikDoOdczytu)
                for wiersz in odczyt:
                    zadID=int(wiersz['id']) + 1

        print("Podaj dane dla zadań (wpisz 'koniec' aby zakończyć):")

        #pętla pobierająca dane od urzytkownika i zapusująca je
        while True:
            nazwa = input(f"Nazwa zadania {zadID}: ").strip()
            if nazwa.lower() == 'koniec':
                break
            if not nazwa:
                    print("Nazwa 1zadania nie może być pusta.")
                    continue 
            while True:
                deadline = input(f"Dedline (format: YYYY-MM-DD HH:MM:SS): ").strip()

                try:
                    #konwersja na chcianhy typ aby sprawdzić czy wpisanio poprawny format deadline
                    deadlineTest = datetime.strptime(deadline, "%Y-%m-%d %H:%M:%S")
                    if deadlineTest >= datetime.now():
                        break
                    else:
                        print("Dedline na zadanie już się skończył")
                except ValueError:
                    print("Niepoprawny format daty.")
                    
            while True:
                czasTrwania =input(f"Czas trwania (w minutach): ").strip()
                try:
                    if czasTrwania.isdigit() and (int(czasTrwania) > 0):
                        czasTrwania = int(czasTrwania)
                        break
                    else: 
                        print("Czas trwania musi liczbą większą od zera.")
                except ValueError:
                    print("Czas trwania musi być liczbą całkowitą")

            zapis.writerow({
                'id': zadID,
                'nazwa': nazwa,
                'deadline': deadline,
                'czasTrwania': czasTrwania
            })
            zadID += 1 

while True:
        print("1. Stwórz plik CSV z zadaniami lub Dopisz zadania do pliku")
        print("2. Wykonaj harmonogram EDF")
        print("3. Wyjście")

        wyb = input("Wybierz opcję: ")

        match wyb:
            case '1':
                while True:
                    sciezka = input("Podaj nazwę pliku CSV do utworzenia (zad.csv): ")
                    if not sciezka:
                        print("Nazwa pliku nie może być pusta.")
                    elif not sciezka.endswith(".csv"):
                        print("Nazwa pliku musi kończyć się na '.csv'.")
                    else: 
                        break
                noweZadaniaDoCSV(sciezka)

            case '2':
                while True:
                    inputplik = input("Podaj nazwę pliku CSV z zadaniami (zad.csv): ")
                    if not os.path.exists(inputplik):
                        print("Plik o podanej nazwie nie istnieje.")
                    else: break

                while True:
                    outputplik = input("Podaj nazwę pliku CSV do zapisu wyników (harm.csv):")
                    if not outputplik:
                        print("Nazwa pliku nie może być pusta.")
                    elif not outputplik.endswith(".csv"):
                        print("Nazwa pliku musi kończyć się na '.csv'.")
                    else:
                        break

                zadania = ReadCSV(inputplik)
                print(f"pobrano dane z pliku {inputplik}")
                harmonogram = edfHarmonogramr(zadania)
                zapHarmonogramDoCSV(harmonogram, outputplik)
 
                print(f"Harmonogram zapisany w pliku {outputplik}")
            case '3':
                print("Koniec programu.")
                break
            case _:
                print("Nieprawidłowy wybór. Spróbuj ponownie.")
