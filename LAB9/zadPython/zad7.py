# Używając funkcji wbudowanych (np. map, filter, reduce), znajdź wszystkie liczby parzyste w
# liście liczb oraz ich sumę.

from functools import reduce

lista=list(range(1,11))
filtista=list(filter(lambda x: x%2==0 ,lista))#filter sprawdza co spełnia warunek a to co nie wywala
suma=reduce(lambda x,y:x+y,filtista)#nie dokońca rozumiem tej funkcji
print(filtista)
print(suma)

lista=list(range(1,11))
mapList=sum(map(lambda x: x if x%2==0 else 0,lista))
#map sprawdza warunek na każdej z liczb więc jest lepsza w np mnożeniu każdej wartości
#tu jak nie spełnia warunku to zamienia nieparzyste na 0
print(mapList)