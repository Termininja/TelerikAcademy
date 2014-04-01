function Task9(input) {
    var CircleRadius = 3;
    var CircleX = 1;
    var CircleY = 1;
    var RectangleTop = 1;
    var RectangleLeft = -1;
    var RectangleWidth = 6;
    var RectangleHeight = 2;

    // Extract the values from the input string
    var words = input.split(' ');
    var x = parseFloat(words[0]);
    var y = parseFloat(words[1]);

    if ((isFloat(x) || isInt(x)) && (isFloat(y) || isInt(y))) {
        // Is the point in the circle
        var inCircle = Math.sqrt(Math.pow(CircleX - x, 2) + Math.pow(CircleY - y, 2)) < CircleRadius;
        display.value += "The point P(" + x + "," + y + ") is " + (inCircle ? "in" : "out of") + " the circle K(1,1,3)\n";

        // Is the point in the rectangle
        var inRectangle = (x > RectangleLeft) && (x < RectangleLeft + RectangleWidth) && (y > RectangleTop - RectangleHeight) && (y < RectangleTop);
        display.value += "The point P(" + x + "," + y + ") is " + (inRectangle ? "in" : "out of") + " the rectangle R(1,-1,6,2)\n";

        // Prints the result
        var result = inCircle && !inRectangle;
        display.value += "So, the point is" + (result ? "" : " not") + " within the circle and out of the rectangle!\n\n";
    }
    else {
        display.value += "Some value is not correct!\n\n";
    }
}