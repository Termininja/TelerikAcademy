//Task 3. Write a function that finds all the occurrences of word in a text:
//The search can case sensitive or case insensitive. Use function overloading

function searchForWord(text, word, sense) {
    return (text.match(new RegExp('\\b' + word + '\\b', (sense == true) ? 'g' : 'gi')) || "").length;
}
