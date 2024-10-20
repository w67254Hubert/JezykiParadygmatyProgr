from operator import truediv


def podzielPaczki(wagi,maxWaga):
    for waga in wagi:
        if waga>maxWaga:
            raise ValueError(f"Paczka o wadze {waga} przekracza maxsymalną wagę wynoszącą {maxWaga}")
    wagiStrored = sorted(wagi ,reverse=True)
    kursy=[]

    for waga in wagiStrored:
        dodano=False
        for kurs in kursy:
            if sum(kurs)+waga<=maxWaga:
                kurs.append(waga)
                dodano=True
                break
        if not dodano:
            kursy.append([waga])

    return len(kursy),kursy

wagi=[10,15,7,20,5,8,10] #kg
maxWaga=25 #kg

#print(podzielPaczki(wagi,maxWaga))

liczbaKursów, kursy= podzielPaczki(wagi,maxWaga)

for i,kurs in enumerate (kursy,1):
    print(f"Kurs {i} : {kurs} suma wag: {sum(kurs)} kg")
