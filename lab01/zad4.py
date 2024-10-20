import random

def DoItemList(listlen):

    itemList=[]
    listLengh=listlen

    for i in range(listLengh):
        itemName = "item "+str(i)

        weight=random.randint(1,15) #waga obiektu kg

        price=random.randint(1,20) #nagroda za wykonanie 

        item=[itemName,weight,price]

        itemList.append(item)
    return itemList

def knapsackAlg(itemlist,maxw):

    def PrisetoWeight(item):
            return item[2]/item[1]
    
    sortedItems = sorted(itemlist, key=PrisetoWeight, reverse=True)
    #przez posorwoeaine wedłóg wartości za 1kg mamy najbardziej wartościowe produkty z przodu
    itemsinback=[]
    backW=0
    profit=0

    if len(itemlist)==0:
        return itemsinback,profit
    
    for item in sortedItems: #poruszając się po posortowanych żeczach sprwawdzamy czy zmieścimy kolejną rzecz w plecaku
        backW=backW+ item[1]
        if backW<=maxw:
            print(backW)
            profit=profit +item[2]
            itemsinback.append(item)
        
    return itemsinback,profit
maxW=15 #max udźwig plecaka kg

numOfItems=10
itemlist=DoItemList(numOfItems)#lista rzeczy

items,profit=knapsackAlg(itemlist,maxW)
print(f'przedmioty w plecaku: nazwa,waga,wartość {items}')#wiem ze nie ładnie pokazuje ale walić
print(len(items))
waga=0
for i in items:
     waga=waga+i[1]
print(waga)
print(f'zysk z szabrowania {profit}')

# wybierz przedmioty tak by zmaksywalizować wartość (bieresz max nagrodę z 1 kg) w plecaku nie przekraczając jego pojemnośći
# wykorzystaj algorytm plecakowy (napsack problem)

