//Task 4. Write a function to count the number of divs on the web page.

function countPageTags(tag) {
    return document.getElementsByTagName(tag).length;
}