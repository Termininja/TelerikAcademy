// Task 1. Write an expression that checks if given integer is odd or even.
function Task1(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        var result = (number % 2 === 0);
        display.value += number + (result ? " is even" : " is odd") + "!\n\n";
    }
    else {
        display.value += "This is not a number!\n\n";
    }
}