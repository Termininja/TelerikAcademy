//Task 7. Write a script that finds the greatest of given 5 variables.

function greatestOf5Variables() {
    //Variables
    var input1 = parseFloat(document.getElementById('input71').value);
    var input2 = parseFloat(document.getElementById('input72').value);
    var input3 = parseFloat(document.getElementById('input73').value);
    var input4 = parseFloat(document.getElementById('input74').value);
    var input5 = parseFloat(document.getElementById('input75').value);
    var result = document.getElementById('result7');

    if (isNaN(input1) && isNaN(input2) && isNaN(input3) &&
        isNaN(input4) && isNaN(input5)) {
        result.innerHTML = null;
    }
    else {
        // Find the greatest number
        var numbers = [input1, input2, input3, input4, input5];
        var greatest = -Infinity;
        for (var i = 0; i < 5; i++) {
            if (numbers[i] >= greatest) {
                greatest = numbers[i];
            }
        }

        // Print the greatest variable
        result.innerHTML = "The greatest number is: " + greatest;
    }
}