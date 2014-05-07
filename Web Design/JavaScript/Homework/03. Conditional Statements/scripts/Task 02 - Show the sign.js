//Task 2. Write a script that shows the sign of the product of three
//numbers without calculating it. Use a sequence of if statements.

function ShowTheSign() {
    //Variables
    var input1 = parseFloat(document.getElementById('input21').value);
    var input2 = parseFloat(document.getElementById('input22').value);
    var input3 = parseFloat(document.getElementById('input23').value);
    var value1 = document.getElementById('val21');
    var value2 = document.getElementById('val22');
    var value3 = document.getElementById('val23');
    var result = document.getElementById('result2');

    //The sign of each one number
    Sign(input1, value1, 1);
    Sign(input2, value2, 2);
    Sign(input3, value3, 3);

    //Define the sign of the product of the three numbers
    if (input1 == 0 || input2 == 0 || input3 == 0) {
        result.innerHTML = "The result of the product is 0!";
    }
    else if (!isNaN(input1) && !isNaN(input2) && !isNaN(input3)) {
        result.innerHTML = "The sign of the product is " +
         ((input1 > 0 ^ input2 > 0 ^ input3 > 0) ? "+" : "-");
    }
    else result.innerHTML = null;
}

//Print the sign of some number
function Sign(input, value, n) {
    value.innerHTML = (isNaN(input)) ?
        null : ("value" + n + ((input > 0) ?
        " > " : ((input < 0) ?
        " < " : " = ")) + "0");
}