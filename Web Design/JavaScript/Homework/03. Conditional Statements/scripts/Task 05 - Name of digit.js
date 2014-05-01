//Task 5. Write script that asks for a digit and shows
//the name of that digit by using a switch statement.

function Task5() {
    //Variables
    var input = document.getElementById('input5').value;
    var result = document.getElementById('result5');
    var name;

    // Check for digit's name in English
    switch (input) {
        case "0": name = "Zero"; break;
        case "1": name = "One"; break;
        case "2": name = "Two"; break;
        case "3": name = "Three"; break;
        case "4": name = "Four"; break;
        case "5": name = "Five"; break;
        case "6": name = "Six"; break;
        case "7": name = "Seven"; break;
        case "8": name = "Eight"; break;
        case "9": name = "Nine"; break;
        default: name = "NaN"; break;
    }

    // Print the name of the digit
    result.innerHTML = (input == "" ? null : ((name != "NaN") ?
        "This is " + name : "This is not a digit!"));
}