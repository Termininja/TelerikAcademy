//Task 1. Write a function that returns the last digit of given integer as an English word.
function lastDigitOfInteger(n) {
    n = n.toString();
    var arr = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

    return arr[parseInt(n[n.length - 1])];
}

//Task 2. Write a function that reverses the digits of given decimal number.
function reverseNumber(n) {
    return ((n < 0) ? "-" : "") + ((n < 0) ? -n : n).toString().split('').reverse().join('');
}

//Task 3. Write a function that finds all the occurrences of word in a text:
//The search can case sensitive or case insensitive. Use function overloading
function searchForWord(text, word, sense) {
    return text.match(new RegExp('\\b' + word + '\\b', (sense == true) ? 'g' : 'gi')).length;
}

//Task 4. Write a function to count the number of divs on the web page.
function countPageTags(tag) {
    return document.getElementsByTagName(tag).length;
}

//Task 5. Write a function that counts how many times given number appears in given array.
//Write a test function to check if the function is working correctly.
function countNumberInArray(array, n) {
    var count = 0;
    for (var i in array) {
        if (array[i] === n) count++;
    }

    return count;
}

//Task 6. Write a function that checks if the element at given position in 
//given array of integers is bigger than its two neighbors (when such exist).
function checkElementNeighbors(array, i) {
    return (array[i] > array[i - 1] && array[i] > array[i + 1] &&
        i > 0 && i < array.length - 1) ? true : false;
}

//Task 7. Write a function that returns the index of the first element bigger than its
//neighbors, or -1, if there’s no such element. Use the function from the previous exercise.
function firstBigger(array) {
    for (var i in array) {
        if (checkElementNeighbors(array, parseInt(i))) return i;
    }

    return -1;
}


window.onload = function () {
    //Generate an array of random integers
    //var array = arrayGenerator(30, 1, 9);

    //alert(lastDigitOfInteger(102354));
    //alert(reverseNumber(-439.42));
    //alert(countPageTags('div'));
    //document.writeln(searchForWord(text, word) + ' : ' + searchForWord(text, word, true));
    //alert(countNumberInArray(array, 2));
    //alert(checkElementNeighbors(array, 12));
    //alert(firstBigger(array));
}

//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
        document.writeln(array[i]);
    }
    return array;
}