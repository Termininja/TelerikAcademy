//Task 5. Write a function that counts how many times given number appears in given array.
//Write a test function to check if the function is working correctly.

function countNumberInArray(array, n) {
    var count = 0;
    for (var i in array) {
        if (array[i] === n) count++;
    }

    return count;
}