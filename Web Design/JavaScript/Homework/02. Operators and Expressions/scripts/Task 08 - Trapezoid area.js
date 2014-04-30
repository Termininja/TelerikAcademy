function Task8(input) {
    // Extract the values from the input string
    var words = input.split(' ');
    var a = parseFloat(words[0]);
    var b = parseFloat(words[1]);
    var h = parseFloat(words[2]);

    // Calculates and prints the result
    if ((isFloat(a) || isInt(a)) && (isFloat(b) || isInt(b)) && (isFloat(h) || isInt(h))) {
        var result = Math.round(((a + b) * h / 2) * 100) / 100;
        display.value += "The trapezoid's area is: " + result + "\n\n";
    }
    else {
        display.value += "Some value is not correct!\n\n";
    }
}