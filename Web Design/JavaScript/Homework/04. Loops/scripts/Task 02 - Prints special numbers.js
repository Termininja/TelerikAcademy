//Task 2. Write a script that prints all the numbers from 1 to N,
//that are not divisible by 3 and 7 at the same time.

function PrintsSpecialNumbers() {
    //Variables
    var N = parseInt(document.getElementById('input2').value);
    var result = document.getElementById('result2');

    result.style.height = "auto";
    result.style.overflowY = "hidden";

    //If input value is a number
    if (!isNaN(N)) {
        var array = [];
        for (var i = 1; i <= N; i++) {
            if (i % 21 != 0) array.push(i);
        }

        //Result-box styling
        if (N > 300) {
            result.style.height = "200px";
            result.style.overflowY = "scroll";
        }

        // Print all numbers from array
        result.innerHTML = array.join(', ');
    }
    else {
        result.innerHTML = null;
    }
}