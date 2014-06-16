//Task 2. Write a function that reverses the digits of given decimal number.

function reverseNumber(n) {
    return ((n < 0) ? "-" : "") + ((n < 0) ? -n : n).toString().split('').reverse().join('');
}