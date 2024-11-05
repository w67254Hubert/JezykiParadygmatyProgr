from cgitb import reset
from functools import reduce

numbers= [1,2,3,4,5,6,7,8,9]

newNumber=[ x ** 2 for x in numbers if x%2==0 ]
print(newNumber)

# map(x,y)
newNumber1= list(map(lambda x: x*2,numbers))#iterowaneiem mnorzymy karzdej liczb4 w niumbers i dajemy wynik do listy
print(newNumber1)

newNumber2= list(filter(lambda x: x%2,numbers)) #filtracfja iterująca po numbers i zabierająca typko lic zxby p0odzielne przez2
print(newNumber2)

newNumber3=reduce(lambda x,y:x+y,numbers)# sumuje elementy pobiera po 2 elementy i je ododaje iteując po liście

a=21 #pgarnie litery dane wcześniej i przypisze za a 21
input=("3+2*6+a")
output=eval(input)#konwersja stringa na matme za pomocą asci
print('suma input', output)#wyświetli


#funkcja do dynamicznego wykonywania kodu
code='''
def greet(name):
    return "hallo, " +name
    
result=greet('world')
'''
exec(code)#działa mimo tego że jest w komentarzu!! ale wywala błąc
print(result)

#ineraktywe powłoki
global_contexst={}
local_contexst={}
exec("x=10",global_contexst,local_contexst)#uwazaj z wykorzystywanie tego
print(local_contexst['x'])


