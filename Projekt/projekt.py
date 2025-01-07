import csv
from queue import PriorityQueue
from datetime import datetime, timedelta

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
    zadania.sort(key=lambda zad: zad['deadline']) #sortowanie kolejności wedłóg deadline


    harmonogram = []
    czasTeraz = datetime.now() #tada czasu z pc np: 2025-01-06 14:35:22
    # czasTeraz = datetime(2025, 1, 6, 14, 35, 22) #dla testu "zatrzymanie czasu"

    for zad in zadania:

        startZad = max(czasTeraz, zad['deadline'] - timedelta(minutes=zad['czasTrwania']))
        koniecZad = startZad + timedelta(minutes=zad['czasTrwania'])

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

# Przykładowy interfejs do tworzenia danych wejściowych
def noweZadaniaDoCSV(scieszka):#wprować pędle by było prościej poprawić wprowadzane wartości
    nazwyKolumn = ['id', 'nazwa', 'deadline', 'czasTrwania']
    with open(scieszka, mode='w', newline='') as plik:
        zapis = csv.DictWriter(plik, fieldnames=nazwyKolumn)
        zapis.writeheader()
        print("Podaj dane dla zadań (wpisz 'koniec' aby zakończyć):")
        zadID = 1
        while True:

            nazwa = input(f"Nazwa zadania {zadID}: ").strip()
            if nazwa.lower() == 'koniec':
                break
            if not nazwa:
                    raise ValueError("Nazwa zadania nie może być pusta.")
            
            deadline = input(f"Dedline (format: YYYY-MM-DD HH:MM:SS): ").strip()
            try:
                deadlineTest = datetime.strptime(deadline, "%Y-%m-%d %H:%M:%S")
            except ValueError:
                raise ValueError("Niepoprawny format daty. Użyj formatu: YYYY-MM-DD HH:MM:SS.")
            
            czasTrwania =input(f"Czas trwania (w minutach): ").strip()
            if not czasTrwania.isdigit() or int(czasTrwania) <= 0:
                raise ValueError("Czas trwania musi być liczbą całkowitą większą od zera.")
            czasTrwania = int(czasTrwania)
            zapis.writerow({
                'id': zadID,
                'nazwa': nazwa,
                'deadline': deadline,
                'czasTrwania': czasTrwania
            })
            zadID += 1

while True:
        print("1. Stwórz plik CSV z zadaniami")
        print("2. Wykonaj harmonogram EDF")
        print("3. Wyjście")

        wyb = input("Wybierz opcję: ")

        match wyb:
            case '1':
                sciezka = input("Podaj nazwę pliku CSV do utworzenia (zad.csv): ")
                if not sciezka:
                    raise ValueError("Nazwa pliku nie może być pusta.")
                noweZadaniaDoCSV(sciezka)
            case '2':
                inputplik = input("Podaj nazwę pliku CSV z zadaniami (zad.csv): ")
                if not inputplik:
                    raise ValueError("Nazwa pliku z zadaniami nie może być pusta.")
                
                outputplik = input("Podaj nazwę pliku CSV do zapisu wyników (chedule.csv): ")
                if not outputplik:
                    raise ValueError("Nazwa pliku do zapisu nie może być pusta.")

                zadania = ReadCSV(inputplik)
                harmonogram = edfHarmonogramr(zadania)
                zapHarmonogramDoCSV(harmonogram, outputplik)
 
                print(f"Harmonogram zapisany w pliku {inputplik}")
            case '3':
                print("Koniec programu.")
                break
            case _:
                print("Nieprawidłowy wybór. Spróbuj ponownie.")
#sprawdź pierwsze zadania tak by nie miesciło się w wyznaczonym terminie dla siebie i czy sie nie zwali reszta
#dodaj edycjeę rekordów z zrobionego pliku
#załatw by można było sortować posortowane (chyba tylko potrzeba czasu trfania)