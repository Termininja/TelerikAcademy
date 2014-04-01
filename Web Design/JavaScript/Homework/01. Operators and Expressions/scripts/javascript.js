var selectTask = "Please, enter the number of some task: ";
var wrongTask = "\nThe number of the task is not corect!\n\n"

var task1 = "Task 1: Write an expression that checks if given integer is odd or even.\n\nPlease, enter some integer number: "
var task2 = "Task 2: Write a boolean expression that checks for given integer if it can be divided (without remainder) by 7 and 5 in the same time.\n\nPlease, enter some integer number: "
var task3 = "Task 3: Write an expression that calculates rectangle's area by given width and height.\n\nPlease, enter the width and height separated by space: "
var task4 = "Task 4: Write an expression that checks for given integer if its third digit (right-to-left) is 7.\n\nPlease, enter some integer number: "
var task5 = "Task 5: Write a boolean expression for finding if the bit 3 (counting from 0) of a given integer is 1 or 0.\n\nPlease, enter some integer number: "
var task6 = "Task 6: Write an expression that checks if given point P(x,y) is within a circle K(O,5).\n\nPlease, enter x and y separated by space: "
var task7 = "Task 7: Write an expression that checks if given positive integer number n (n ≤ 100) is prime.\n\nPlease, enter some positive integer number: "
var task8 = "Task 8: Write an expression that calculates trapezoid's area by given sides a and b and height h.\n\nPlease, enter a, b and h separated by space: "
var task9 = "Task 9: Write an expression that checks for given point P(x,y) if it is within the circle K(1,1,3) and out of the rectangle R(top=1, left=-1, width=6, height=2).\n\nPlease, enter x and y separated by space: "

var checkTask = true;
var task = 0;

// All information is taken and returned from element with id="Display"
var display = document.getElementById('Display');

// When the page is loaded
window.onload = function () {
    display.value = selectTask;
};

// When the user type something
function Input(str) {
    var command = str.substring(0, str.length - 1);
    var lastCommand = command.substring(command.lastIndexOf('\n') + 1);

    // When 'Enter' is pressed
    if (display.value.substr(display.value.length - 1) === '\n') {
        if (checkTask) {
            var end = true;

            task = lastCommand.substring(39);
            switch (task) {
                case "1": display.value = task1; break;
                case "2": display.value = task2; break;
                case "3": display.value = task3; break;
                case "4": display.value = task4; break;
                case "5": display.value = task5; break;
                case "6": display.value = task6; break;
                case "7": display.value = task7; break;
                case "8": display.value = task8; break;
                case "9": display.value = task9; break;
                default:
                    display.value += wrongTask + selectTask;
                    end = false;
                    break;
            }

            if (end) checkTask = false;
        }
        else {
            var input = lastCommand.substring(lastCommand.search(': ') + 2);

            switch (task) {
                case "1": Task1(input); break;
                case "2": Task2(input); break;
                case "3": Task3(input); break;
                case "4": Task4(input); break;
                case "5": Task5(input); break;
                case "6": Task6(input); break;
                case "7": Task7(input); break;
                case "8": Task8(input); break;
                case "9": Task9(input); break;
                default: break;
            }

            display.value += selectTask;
            checkTask = true;
        }
    }
}

// Check some string for integer
function isInt(n) {
    return n === +n && n === (n | 0);
}

// Check some string for float
function isFloat(n) {
    return n === +n && n !== (n | 0);
}
