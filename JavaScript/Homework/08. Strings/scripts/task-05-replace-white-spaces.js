//Task 5. Write a function that replaces non breaking white-spaces in a text with &nbsp;

function replaceWhiteSpaces(str) {
    return str.replace(/\s/g, '&nbsp;');
}