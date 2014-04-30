function Task2(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        var result = (number % 35 === 0);
        display.value += "The number " + number + " can " + (result ? "" : "not ") + "be divided by 7 and 5 in the same time!\n\n";
    }
    else {
        display.value += "This is not a number!\n\n";
    }
}