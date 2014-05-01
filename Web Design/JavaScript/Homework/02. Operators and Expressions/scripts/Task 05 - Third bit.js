// Task 5. Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.
function Task5(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        // The binary representation of the number
        var binary = number.toString(2);
        display.value += "The binary representation of " + number + " is " + binary;

        // Prints the result
        var result = (number >> 3) & 1;
        display.value += "\nThe third bit is " + result + "!\n\n";
    }
    else {
        display.value += "This is not a number!\n\n";
    }
}