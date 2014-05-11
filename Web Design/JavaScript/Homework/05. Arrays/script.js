//Task 1. Write a script that allocates array of 20 integers and initializes each
//element by its index multiplied by 5. Print the obtained array on the console.
function multipliedBy5() {

    //Allocates an array of 20 integers
    var array = [];
    for (var i = 0; i < 20; i++) {
        array[i] = i * 5;
    }
    console.log(array.join(' '));
}

//Task 2. Write a script that compares two char arrays lexicographically (letter by letter).
function compare2CharArrays() {
    //Generate two arrays of chars
    var charArray1 = [];
    var charArray2 = [];
    var arrayLength = 20

    for (var i = 0; i < arrayLength; i++) {
        var generator1 = Math.floor(Math.random() * 26);
        var generator2 = Math.floor(Math.random() * 26);
        charArray1[i] = String.fromCharCode(65 + generator1);
        charArray2[i] = String.fromCharCode(65 + generator2);
    }

    //Compares both arrays lexicographically
    var result = [];
    for (var i = 0; i < arrayLength; i++) {
        if (charArray1[i] === charArray2[i]) result[i] = '=';
        else if (charArray1[i] > charArray2[i]) result[i] = '>';
        else result[i] = '<';
    }

    return result;
}

//Task 3. Write a script that finds the maximal sequence of equal elements in an array.
//Example: {2, 1, 1, 2, 3, 3, 2, 2, 2, 1} → {2, 2, 2}
function maxSequence() {
    //Variables
    var array = arrayGenerator(30, 1, 3);
    var maxCount = 0;
    var count = 1;
    var maxElement = null;
    var element = array[0];

    //Finds the maximal sequence of equal elements
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1]) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                maxElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    return maxCount;
}

//Task 4. Write a script that finds the maximal increasing sequence in an array.
//Example: {3, 2, 3, 4, 2, 2, 4} → {2, 3, 4}
function maxIncreasingSequence() {
    //Variables
    var array = arrayGenerator(30, 1, 5);
    var maxCount = 0;
    var count = 1;
    var maxElement = null;
    var element = array[0];

    //Finds the maximal increasing sequence
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1] + 1) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                maxElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    return maxCount;
}

//Task 5. Write a script to sort the elements in an array in increasing order.
//Use the "selection sort" algorithm: Find the smallest element, move it at the first
//position, find the smallest from the rest, move it at the second position, etc.
//Hint: Use a second array
function sortArray() {
    var array = arrayGenerator(30, -100, 200);

    for (var i = 0; i < array.length - 1; i++) {
        //Find the smallest element
        var minElement = array[i];
        var minIndex = i;
        for (var j = i + 1; j < array.length; j++) {
            if (array[j] < minElement) {
                minElement = array[j];
                minIndex = j;
            }
        }

        //Swap the current element with the smallest element
        var tempElement = array[i];
        array[i] = minElement;
        array[minIndex] = tempElement;
    }

    return array;
}

//Task 6. Write a program that finds the most frequent number in an array.
//Example: {4, 1, 1, 4, 2, 3, 4, 4, 1, 2, 4, 9, 3} → 4 (5 times)
function mostFrequentNumber() {
    //Variables
    var maxCount = 0;
    var count = 1;
    var maxElement = null;
    var element = array[0];
    var array = arrayGenerator(30, 1, 5);

    //Sort the elements in array in increasing order
    array.sort(function (a, b) { return a - b });

    //Finds the most frequent number in array
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1]) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                maxElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    return maxCount;
}

//Task 7. Write a program that finds the index of given element
//in a sorted array of integers by using the binary search algorithm.
function binarySearch() {
    //Generate an sorted array of integers
    var array = arrayGenerator(30, 0, 100);
    array.sort(function (a, b) { return a - b });

    var givenElement = 47;

    var min = 0;
    var max = array.length - 1;

    //Finds the index of the given element in array
    while (max > min) {
        var mid = Math.floor((min + max) / 2);
        if (givenElement <= array[mid]) max = mid;
        else min = mid + 1;

        // Print the result
        if (min == max && array[min] == givenElement) return min;
        else if (min == max) return -1;
    }
}

window.onload = function () {


}




//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
    }
    return array;
}