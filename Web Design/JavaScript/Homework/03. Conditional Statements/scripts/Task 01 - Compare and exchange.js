//Task 1. Write an if statement that examines two integers and
//exchanges their values if the first is greater than the second one.

function CompareAndExchange() {
    //Variables
    var input1 = parseInt(document.getElementById('input11').value);
    var input2 = parseInt(document.getElementById('input12').value);
    var value1 = document.getElementById('val11');
    var value2 = document.getElementById('val12');
    var result = document.getElementById('result1');

    //Compare both values
    if (!(isNaN(input1) || isNaN(input2))) {
        if (input1 < input2) {
            result.innerHTML = "value1 < value2";
        }
        else if (input1 > input2) {
            result.innerHTML = "value1 > value2";
            var temp = input1;
            input1 = input2;
            input2 = temp;
            result.innerHTML += " (both values are exchanged)";
        }
        else {
            result.innerHTML = "value1 = value2";
        }
    }
    else {
        result.innerHTML = null;
    }

    // Print the final values
    value1.innerHTML = isNaN(input1) ? null : "value1 = " + input1;
    value2.innerHTML = isNaN(input2) ? null : "value2 = " + input2;
}