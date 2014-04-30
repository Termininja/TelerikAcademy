function Task6(input) {
    var CircleRadius = 5;
    var words = input.split(' ');
    var x = parseFloat(words[0]);
    var y = parseFloat(words[1]);
    if ((isFloat(x) || isInt(x)) && (isFloat(y) || isInt(y))) {
        // The distance from the center of the circle
        var distance = Math.sqrt(x * x + y * y);

        // Checks the position of the point
        display.value += "The point P(" + x + "," + y + ") is ";

        if (distance < CircleRadius) display.value += "within ";
        else if (distance > CircleRadius) display.value += "without ";
        else display.value += "on ";

        display.value += "the circle K(0,5)!\n\n";
    }
    else {
        display.value += "Some value is not correct!\n\n";
    }
}