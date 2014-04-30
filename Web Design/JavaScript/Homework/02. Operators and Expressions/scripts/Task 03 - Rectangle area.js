function Task3(input) {
    var words = input.split(' ');
    var width = parseFloat(words[0]);
    var height = parseFloat(words[1]);
    if ((isFloat(width) || isInt(width)) && (isFloat(height) || isInt(height))) {
        var result = Math.round(width * height * 100) / 100;
        display.value += "The rectangle's area is: " + result + "\n\n";
    }
    else {
        display.value += "Some value is not correct!\n\n";
    }
}