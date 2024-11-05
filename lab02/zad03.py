def dynamicDataAnalysis(data):
    # Wyszukiwanie największej liczby
    numericValues = filter(lambda x: isinstance(x, (int, float)), data)  # Wybór liczb
    maxNumber = max(numericValues, default=None)  # Znalezienie max liczby

    # Wyszukiwanie najdłuższego napisu
    strings = filter(lambda x: isinstance(x, str), data)  # Wybór string
    longestString = max(strings, key=len, default=None)  # Znalezienie najdłuższego napisu

    # Wyszukiwanie krotki z największą liczbą elementów
    tuples = filter(lambda x: isinstance(x, tuple), data)  # Wybór krotek
    largestTuple = max(tuples, key=len, default=None)  # Znalezienie krotki z największą liczbą elementów

    return maxNumber, longestString, largestTuple

# Przykład użycia
data = [123, "elo", (1, 2, 3), [1, 2], "swiecie!", 3.14, (4, 5, 6, 7,'asda'), {"key": "value"},42, "siemson", (1, 2, 3), [4, 5, 6], {"klucz": "wartosc"}, 3.14, 
    "wodzik", (7, 8, 9, 10), "Python", (11,), 99,[0,0,0]]
result = dynamicDataAnalysis(data)
print("Największa liczba:", result[0])
print("Najdłuższy napis:", result[1])
print("Krotka o największej liczbie elementów:", result[2])
