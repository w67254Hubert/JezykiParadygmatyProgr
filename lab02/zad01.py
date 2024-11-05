import string

def countTextElements(text): # Funkcja zliczająca słowa, zdania i akapity

    words = text.split()
    sentences = text.split('.')
    paragraphs = text.split('\n\n')
    return len(words), len(sentences), len(paragraphs)

stop_words = ["i", "a", "the", "and", "to", "of", "in", "that", "is", "for", "it", "on", "as", "by", "at", "an","or","be"] #lista słów pomijanych "stop words"

def findCommonWords(text): # Funkcja do usuwająca stop words i znajdująca najczęstsze słowa
    words = text.split()
    filteredWords=[]
    for word in words:
        changeWord = word.strip(string.punctuation).lower()
        if word.lower() not in stop_words:
            filteredWords.append(changeWord)

    #print(filteredWords)
    
    wordCounts = {}
    for word in filteredWords:
        wordCounts[word] = wordCounts.get(word, 0) + 1
    sorted_words = sorted(wordCounts.items(), key=lambda item: item[1], reverse=True)
    return sorted_words

# Funkcja do odwracania słów zaczynających się na 'a' lub 'A'
def reverseWordsStartingWithA(text):
    words = text.split()
    transformed_words = []
    for word in words:
        if word.lower().startswith('a'):
            transformed_words.append(word[::-1])
        else:
            transformed_words.append(word)
    return ' '.join(transformed_words)

#teks
text = """ Test ! aleksandra ! In literary theory, a text is any object that can be "read", whether this object is a work of literature, a street sign, an arrangement of buildings on a city block, or styles of clothing.[citation needed] It is a set of signs that is available to be reconstructed by a reader (or observer) if sufficient interpretants are available.[citation needed] This set of signs is considered in terms of the informative message's content, rather than in terms of its physical form or the medium in which it is represented.[citation needed]

Within the field of literary criticism, "text" also refers to the original information content of a particular piece of writing; that is, the "text" of a work is that primal symbolic arrangement of letters as originally composed, apart from later alterations, deterioration, commentary, translations, paratext, etc. Therefore, when literary criticism is concerned with the determination of a "text", it is concerned with the distinguishing of the original information content from whatever has been added to or subtracted from that content as it appears in a given textual document."""

#wywołanie funkcji zliczającej 
wordCount, sentenceCount, paragraphCount = countTextElements(text)
print(f'Liczba słów: {wordCount}, Liczba zdań: {sentenceCount}, Liczba akapitów: {paragraphCount}')
print()
# wywołanie funkcji liczącej słowa
commonWords = findCommonWords(text)
print(f'tob 10 najczęściej występujących słów {commonWords[0:10]}')
print()
# Transformacja słów
transformedText = reverseWordsStartingWithA(text)
print(f'Transformowany tekst: {transformedText}')
