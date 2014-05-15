//Task 6. Write a function that extracts the content of a html page given as text.
//The function should return anything that is in a tag, without the tags.

function htmlToText(str) {
    return str.replace(/<.*?>/g, '');
}