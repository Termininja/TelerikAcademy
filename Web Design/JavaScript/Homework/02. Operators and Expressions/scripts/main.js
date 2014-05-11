//Variables
var selectTask = "Please, enter the number of some task: ";
var wrongTask = "\nThe number of the task is not corect!\n\n"

var task1string = "Task 1: Write an expression that checks if given integer is odd or even.\n\nPlease, enter some integer number: "
var task2string = "Task 2: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.\n\nPlease, enter some integer number: "
var task3string = "Task 3: Write an expression that calculates rectangle's area by given width and height.\n\nPlease, enter the width and height separated by space: "
var task4string = "Task 4: Write an expression that checks for given integer if its third digit (right-to-left) is 7.\n\nPlease, enter some integer number: "
var task5string = "Task 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.\n\nPlease, enter some integer number: "
var task6string = "Task 6: Write an expression that checks if given point P(x,y) is within a circle K(O,5).\n\nPlease, enter x and y separated by space: "
var task7string = "Task 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime.\n\nPlease, enter some positive integer number: "
var task8string = "Task 8: Write an expression that calculates trapezoid area by given sides a and b and height h.\n\nPlease, enter a, b and h separated by space: "
var task9string = "Task 9: Write an expression that checks for given point P(x,y) if it is within the circle K(1,1,3) and out of the rectangle R(top=1, left=-1, width=6, height=2).\n\nPlease, enter x and y separated by space: "

var checkTask = true;
var task = 0;

var display = document.getElementById('Display');
var text = document.getElementById('JSFile');

//Invert some color
function invert(rgb) {
    rgb = [].slice.call(arguments).join(",").replace(/rgb\(|\)|rgba\(|\)|\s/gi, '').split(',');
    for (var i = 0; i < rgb.length; i++) rgb[i] = (i === 3 ? 1 : 255) - rgb[i];
    return rgb.join(", ");
}

//Block all arrow keys
window.onkeyup = function (e) {
    if (e.keyCode == 37 || e.keyCode == 38 || e.keyCode == 39 || e.keyCode == 40) {
        setFocus();
    }
}

//Executed when page is loaded
window.onload = function () {
    display.value = selectTask;
    setFocus();
}

//Focus over display area
function setFocus() {
    display.focus();
    var temp = display.value;
    display.value = "";
    display.value += temp;
}

//When the user type something
function input(str) {
    var command = str.substring(0, str.length - 1);
    var lastCommand = command.substring(command.lastIndexOf('\n') + 1);

    //When 'Enter' is pressed
    if (display.value.substr(display.value.length - 1) === '\n') {
        if (checkTask) {
            var end = true;
            task = lastCommand.substring(39);
            switch (task) {
                case "1":
                    display.value = task1string;
                    text.src = "scripts/Task 01 - Odd or even.js";
                    break;
                case "2":
                    display.value = task2string;
                    text.src = "scripts/Task 02 - Devided by 7 and 5.js";
                    break;
                case "3":
                    display.value = task3string;
                    text.src = "scripts/Task 03 - Rectangle area.js";
                    break;
                case "4":
                    display.value = task4string;
                    text.src = "scripts/Task 04 - Third digit.js";
                    break;
                case "5":
                    display.value = task5string;
                    text.src = "scripts/Task 05 - Third bit.js";
                    break;
                case "6":
                    display.value = task6string;
                    text.src = "scripts/Task 06 - Point and circle.js";
                    break;
                case "7":
                    display.value = task7string;
                    text.src = "scripts/Task 07 - Prime numbers.js";
                    break;
                case "8":
                    display.value = task8string;
                    text.src = "scripts/Task 08 - Trapezoid area.js";
                    break;
                case "9":
                    display.value = task9string;
                    text.src = "scripts/Task 09 - Point, circle and rectangle.js";
                    break;
                default:
                    display.value += wrongTask + selectTask;
                    text.src = "";
                    end = false;
                    break;
            }

            if (end) checkTask = false;
        }
        else {
            var input = lastCommand.substring(lastCommand.search(': ') + 2);
            switch (task) {
                case "1": oddOrEven(input); break;
                case "2": devidedBy7And5(input); break;
                case "3": rectangularArea(input); break;
                case "4": thirdDigit(input); break;
                case "5": thirdBit(input); break;
                case "6": pointAndCircle(input); break;
                case "7": primeNumbers(input); break;
                case "8": trapezoidArea(input); break;
                case "9": pointCircleAndRectangle(input); break;
                default: break;
            }
            display.value += selectTask;
            checkTask = true;
        }
    }
}

//Check some string for integer
function isInt(n) {
    return n === +n && n === (n | 0);
}

//Check some string for float
function isFloat(n) {
    return n === +n && n !== (n | 0);
}