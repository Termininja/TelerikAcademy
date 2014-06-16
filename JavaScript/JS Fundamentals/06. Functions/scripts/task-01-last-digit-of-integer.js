//Task 1. Write a function that returns the last digit of given integer as an English word.

function lastDigitOfInteger(n) {
    n = n.toString();
    var arr = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven', 'eight', 'nine'];

    return arr[parseInt(n[n.length - 1])];
}