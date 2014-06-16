//Task 10. Write a program that extracts from a given text all palindromes.

function extractPalindromes(str) {
    var words = str.match(/\b\w*\b/g);
    var listOfPalindromes = [];
    for (var w in words) {
        if (words[w].length > 1 && isPalindrome(words[w])) {
            listOfPalindromes.push(words[w]);
        }
    }

    function isPalindrome(word) {
        for (var i = 0; i < word.length / 2; i++) {
            if (word[i] != word[word.length - 1 - i]) {
                return false;
            }
        }
        return true;
    }

    return listOfPalindromes;
}