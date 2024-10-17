from collections import deque

def BFS (graph,start,end):
    queque=deque([[start]]) #kolekcja do przechowywania ścieżek
    visited=set() #wiesxzchołki odwiedzonew

    while queque:
        path=queque.popleft()
        node=path[-1]#ostatni wiszchołek w ścierzce
        #jeżeli wieszchołek jesrt celem zwracaj śeirzeke
        if node ==end :return path

        if node not in visited:
            for neighbour in graph.get(node,[]):
                new_path=list(path)
                new_path.append(neighbour)
                queque.append(new_path)
            visited.add(node)
    return None #jeśli nie ma ścierzki

graph={
    "A":["B","C"],"B":["A"]
}