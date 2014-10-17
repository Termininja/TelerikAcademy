//Task 3. Write a script that finds the max and min number from a sequence of numbers.

function minAndMaxOfSequence() {
    //Variables
    var input = document.getElementById('input3').value.trim().split(' ');
    var result1 = document.getElementById('result31');
    var result2 = document.getElementById('result32');
    var result3 = document.getElementById('result33');

    result3.innerHTML = null;
    if (input[0] != "") {
        var min = Infinity;
        var max = -Infinity;
        for (var i = 0; i < input.length; i++) {
            var currentNumber = parseFloat(input[i]);

            if (isNaN(currentNumber)) {
                //If the current value is not a number
                result1.innerHTML = null;
                result2.innerHTML = null;
                result3.innerHTML = "Wrong input!";
                break;
            }
            else {
                //If the current value is a number
                if (currentNumber < min) min = currentNumber;
                if (currentNumber > max) max = currentNumber;
                result1.innerHTML = "Min: " + min;
                result2.innerHTML = "Max: " + max;
            }
        }
    }
    else {
        //If input value is empty
        result1.innerHTML = null;
        result2.innerHTML = null;
    }
}