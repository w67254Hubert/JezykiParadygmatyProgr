import random 
import string

#zadanie,czas wykonania, nagroda
tasks=[["zadanie A",1,100],["zadanie B",2,30],["zadanie C",3,100],["zadanie D",2,50]]



taskList=[]

listLengh=random.randint(1,10)

for i in range(listLengh):
    
    taskName = random.choice(string.ascii_uppercase)

    price=random.randint(1,100) #nagroda za wykonanie

    time=random.randint(1,60) #czas

    task=[taskName,price,time]

    taskList.append(task)

    
# print(taskList)