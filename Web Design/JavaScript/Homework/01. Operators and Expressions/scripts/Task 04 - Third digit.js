function Task4(input) {
    var number = parseInt(input);

    if (isInt(number)) {
        var result = (Math.round((number / 100) % 10) === 7);
        display.value += "The third digit is " + (result ? "" : "not ") + "7!\n\n";
    }
    else {
        display.value += "This is not a number!\n\n";
    }
}