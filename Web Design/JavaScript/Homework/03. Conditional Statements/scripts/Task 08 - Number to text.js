//Task 8. Write a script that converts a number to 
//a text corresponding to its English pronunciation.

function Task8() {
    //Some basic number names and prefixes
    var names = ['zero', 'one', 'two', 'three', 'four', 'five', 'six', 'seven',
        'eight', 'nine', 'ten', 'eleven', 'twelve', 'thirteen', 'fourteen',
        'fifteen', 'sixteen', 'seventeen', 'eighteen', 'nineteen', 'twenty'];
    var bigNames = ['', 'm', 'b', 'tr', 'quadr', 'quint', 'sext', 'sept', 'oct',
        'non', 'dec', 'vigint', 'trigint', 'quadragint', 'quinquagint',
        'sexagint', 'septuagint', 'octogint', 'nonagint', 'cent'];
    var prefixes = ['', 'un', 'duo', 'tre', 'quattuor', 'quin', 'sex',
        'septen', 'octo', 'novem'];

    //Tenths
    names[30] = "thirty";
    names[40] = "forty";
    names[50] = "fifty";
    names[60] = "sixty";
    names[70] = "seventy";
    names[80] = "eighty";
    names[90] = "ninety";

    var maxLength = 600;
    var input = document.getElementById('input8').value;
    var result = document.getElementById('result8');
    result.style.color = "red";

    //Empty or wrong input string
    if (input === "") result.innerHTML = "";
    else if (isNaN(parseInt(input))) {
        result.innerHTML = "This is not a number!";
    }
    else {
        if (parseInt(input) >= 0) {
            if (input == "1" + new Array(101).join("0")) {
                //10^100
                result.innerHTML = "Googol";
            }
            else if (input.length <= maxLength + 1) {
                result.style.color = "#333";

                //Get the name of the number
                var name = Mil(input, maxLength);
                result.innerHTML = name[0].toUpperCase() + name.slice(1);
            }
            else result.innerHTML = "The number is too big!";
        }
        else result.innerHTML = "The number has to be positive!";
    }

    //Recursion from 10^600 (k = 600) to 10^3 (k = 3)
    function Mil(n, k) {
        var result = "";
        if ((n.replace(/^0+/, '')).length > k) {
            result = ((k == 2) ? names[parseInt(n / 100)] :
                Mil(n.substr(0, n.length - k), ((k == 3) ? 2 : k - 3))) + " " +
                ((k == 2) ? "hundred" : ((k == 3) ? "thousand" : (((k >= 60) ?
                (prefixes[parseInt((k % 60) / 6)] + bigNames[parseInt(k / 60) + 9]) :
                bigNames[parseInt(k / 6)]) + ((k % 6 === 0) ? "illion" : "illiard"))));

            n = n.substring(n.length - k);
            if (n > 0) result += ((k == 2) ? " and " : " ") + Hundreds(n, k);
        }
        else result += Hundreds(n, k);
        return result;
    }

    //Get the name of the number (0 to 999)
    function Hundreds(n, k) {
        return (k == 2) ? Tens(n) : ((k == 3) ? Mil(n, 2) : Mil(n, k - 3));
    }

    //Get the name of the number (0 to 99)
    function Tens(n) {
        return (names[n % 100] !== undefined) ? names[n % 100] :
            (names[(parseInt((n % 100) / 10)) * 10] +
            ((((n % 100) / 10) * 10 > 0 && n % 10 > 0) ? "-" : "") +
            names[n % 10]);
    }
}