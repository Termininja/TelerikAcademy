//Task 11. Write a function that formats a string using placeholders:
//var str = stringFormat("Hello {0}!","Peter"); str = "Hello Peter!";
//The function should work with up to 30 placeholders and all types.

function stringFormat(str) {
    for (var i in arguments) {
        str = str.replace(new RegExp('\\{' + i + '}', 'g'), arguments[+i + 1]);
    }

    return str;
}