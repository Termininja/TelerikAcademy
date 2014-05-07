//Task 6. Write a script that enters the coefficients a, b and c
//of a quadratic equation and calculates and prints its real roots.

function QuadraticEquation() {
    //Variables
    var a = parseFloat(document.getElementById('input61').value);
    var b = parseFloat(document.getElementById('input62').value);
    var c = parseFloat(document.getElementById('input63').value);
    var value1 = document.getElementById('val61');
    var value2 = document.getElementById('val62');
    var value3 = document.getElementById('val63');
    var result = document.getElementById('result6');

    //Print the coefficients
    value1.innerHTML = (isNaN(a)) ? null : "a = " + a;
    value2.innerHTML = (isNaN(b)) ? null : "b = " + b;
    value3.innerHTML = (isNaN(c)) ? null : "c = " + c;

    if (isNaN(a) || isNaN(b) || isNaN(c)) {
        result.innerHTML = null;
    }
    else {
        //Discriminant of quadratic equation
        var D = Math.pow(b, 2) - 4 * a * c;

        result.innerHTML =
            "The quadratic equation ax² + bx + c = 0 ";
        if (D < 0) {
            //If doesn't have real roots
            result.innerHTML +=
                "doesn't have real roots!";
        }
        else if (D == 0) {
            //If there is only one real root 'x'
            var x = -b / 2 * a;
            result.innerHTML +=
                "has only one real root: x = " +
                x.toFixed(3);
        }
        else {
            //If there are two real roots 'x1' and 'x2'
            var x1 = (-b + Math.sqrt(D)) / 2 * a;
            var x2 = (-b - Math.sqrt(D)) / 2 * a;
            result.innerHTML +=
                "has two real roots: x1 = " +
                x1.toFixed(3) + ", x2 = " + x2.toFixed(3);
        }
    }
}