# PYTHON 4. Napisz skrypt do analizy danych z pliku CSV, który oblicza średnią dla wybranej kolumny.

import csv

def obliczSrednia(scieszka, nazwaKolumny):
    with open(scieszka, mode='r') as daneCSV: #otwieram plik
        dane = csv.DictReader(daneCSV)#organizacja danych w rekordy złowników
        list = []
        ileRekordow = 0
        for wiersz in dane:
            if wiersz[nazwaKolumny]:
                list.append(wiersz[nazwaKolumny])
                ileRekordow += 1

        suma=sum(list[0:])
        if ileRekordow > 0:
            srednia = suma / ileRekordow
        else:
            return 0
        return srednia

scieszka = 'dane.csv'  # ścieszka do pliku CSV
nazwaKolumny = 'kolumna2'  # Nazwa kolumny z której liczymy średnią

srednia = obliczSrednia(scieszka, nazwaKolumny)
print(f'Średnia kolumny {nazwaKolumny} wynosi: {srednia}')
