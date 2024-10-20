
import random

#zadanie,czas wykonania, nagroda
#tasks=[["zadanie A",1,100],["zadanie B",2,30],["zadanie C",3,100],["zadanie D",2,50]]

def DoTaskList(listlen):
    taskList=[]

    listLengh=listlen

    for i in range(listLengh):
        taskName = "zad "+str(i)

        time=random.randint(1,60) #czas

        price=random.randint(1,100) #nagroda za wykonanie

        task=[taskName,price,time]

        taskList.append(task)
    return taskList

def rewardToTime(task):
    return task[1] / task[2] #dzielenie czasu przez nagrodę wynik

def sortTaskList(taskList):
    # Sortuj według stosunku nagroda/czas, w kolejności malejącej
    sorted_tasks = sorted(taskList, key=rewardToTime, reverse=True)
    return sorted_tasks

def WaitingTimeForTask(taskList): #czas po którym zadanie zostanie rozpoczęte
    waitingTime = 0
    timeslist=[]
    for task in taskList:
        name = task[0]
        Time = task[2]
        nametime=[name,waitingTime]
        timeslist.append(nametime)
        waitingTime +=Time

    return timeslist


def totalWaitingTime(taskList):
    waitingTime = 0
    for task in taskList:
        Time = task[2]
        waitingTime +=Time

    return waitingTime



listLen=20 #długość listy zadań

taskList=DoTaskList(listLen)

print('lista zadań:')
print(taskList)

SortedTaskList=sortTaskList(taskList)
print('kolejność wykonania przedstawionej listy zadań zadań:')
# for task in SortedTaskList:
#     print(task)
print(SortedTaskList)

taskstartTime=WaitingTimeForTask(SortedTaskList) #czas po którym zadanie zostanie rozpoczęte
print('czasy rozpoczęcia zadań:')
print(taskstartTime)
# for task in taskstartTime:
#     print(task)
totalTime=totalWaitingTime(taskList)
print(f'Całkowity czas na wykonanie zadań wynosi {totalTime} min')

#program tworzy liste zadań
#następnie segreguje zadania na podstawie zalarzności czas / nagroda
#liczy czas na wykonanie zadań z listy

#funkcja licząca czas w którym zostaną rozpoczęte zadania
