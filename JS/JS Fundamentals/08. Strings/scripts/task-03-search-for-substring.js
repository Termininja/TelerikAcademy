//Task 3. Write a function that finds how many times a substring
//is contained in a given text (perform case insensitive search).

function searchForSubstring(str, substring) {
    return (str.match(new RegExp(substring, 'gi')) || '').length;
}