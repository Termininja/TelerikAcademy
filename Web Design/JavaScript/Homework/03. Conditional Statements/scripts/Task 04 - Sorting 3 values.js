//Task 4. Sort 3 numbers in descending order using nested if statements.

function Task4() {
    //Variables
    var input1 = parseFloat(document.getElementById('input41').value);
    var input2 = parseFloat(document.getElementById('input42').value);
    var input3 = parseFloat(document.getElementById('input43').value);
    var value1 = document.getElementById('val41');
    var value2 = document.getElementById('val42');
    var value3 = document.getElementById('val43');
    var result = document.getElementById('result4');
    var sorted = [input1, input2, input3];

    if (isNaN(input1) || isNaN(input2) || isNaN(input3)) {
        result.innerHTML = null;
    }
    else {
        //Sort in descending order
        if (input2 > input1 && input2 > input3) {
            var temp = input1;
            sorted[0] = input2;
            if (temp > input3) {
                sorted[1] = temp;
            }
            else {
                sorted[1] = input3;
                sorted[2] = temp;
            }
        }
        else if (input3 > input1 && input3 > input2) {
            var temp = input1;
            sorted[0] = input3;
            if (temp > input2) {
                sorted[2] = input2;
                sorted[1] = temp;
            }
            else {
                sorted[2] = temp;
            }
        }
        else {
            if (input3 > input2) {
                var temp = input2;
                sorted[1] = input3;
                sorted[2] = temp;
            }
        }

        //Print the sorted numbers
        result.innerHTML = "Sorted in descending order: " +
            sorted[0] + ", " + sorted[1] + ", " + sorted[2];
    }
    value1.innerHTML = (isNaN(input1)) ? null : "value1 = " + sorted[0];
    value2.innerHTML = (isNaN(input2)) ? null : "value2 = " + sorted[1];
    value3.innerHTML = (isNaN(input3)) ? null : "value3 = " + sorted[2];
}
