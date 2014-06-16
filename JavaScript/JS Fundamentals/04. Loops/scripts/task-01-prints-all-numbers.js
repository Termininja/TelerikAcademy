//Task 1. Write a script that prints all the numbers from 1 to N.

function printsAllNumbers() {
    //Variables
    var N = parseInt(document.getElementById('input1').value);
    var result = document.getElementById('result1');

    result.style.height = "auto";
    result.style.overflowY = "hidden";

    //If input value is a number
    if (!isNaN(N)) {
        var array = [];
        for (var i = 1; i <= N; i++) {
            //Push all numbers in some array
            array.push(i);
        }

        //Result-box styling
        if (N > 300) {
            result.style.height = "200px";
            result.style.overflowY = "scroll";
        }

        //Print all numbers from array
        result.innerHTML = array.join(', ');
    }
    else {
        result.innerHTML = null;
    }
}