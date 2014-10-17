//Task 2. Write a function to check if in a given expression the brackets are put correctly.

function checkBrackets(str) {
    var brackets = 0;
    for (var char in str) {
        brackets += (str[char] == '(') ? 1 : ((str[char] == ')') ? -1 : 0);

        if (brackets < 0) {
            return false;
        }
    }

    return (brackets === 0) ? true : false;
}