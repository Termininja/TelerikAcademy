// Task 4. Write an expression that checks for given integer if its third digit (right-to-left) is 7.
function thirdDigit(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        var result = (number.toString()[number.toString().length - 3] === "7");
        display.value += "The third digit is " + (result ? "" : "not ") + "7!\n\n";
    }
    else {
        display.value += "This is not a number!\n\n";
    }
}