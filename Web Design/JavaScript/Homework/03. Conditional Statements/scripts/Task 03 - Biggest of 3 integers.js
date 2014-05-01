//Task 3. Write a script that finds the biggest of three integers.

function Task3() {
    //Variables
    var input1 = parseInt(document.getElementById('input31').value);
    var input2 = parseInt(document.getElementById('input32').value);
    var input3 = parseInt(document.getElementById('input33').value);
    var result = document.getElementById('result3');
    var biggest;

    //Find the biggest of three integers
    result.innerHTML = "The biggest number is ";
    if (isNaN(input1) && isNaN(input2) && isNaN(input3)) {
        result.innerHTML = null;
    }
    else {
        input1 = (isNaN(input1)) ? -Infinity : input1;
        input2 = (isNaN(input2)) ? -Infinity : input2;
        input3 = (isNaN(input3)) ? -Infinity : input3;

        if (input1 > input2) {
            biggest = (input1 > input3) ? input1 : input3;
        }
        else {
            biggest = (input2 > input3) ? input2 : input3;
        }

        //Print the final result
        result.innerHTML += biggest;
    }
}

