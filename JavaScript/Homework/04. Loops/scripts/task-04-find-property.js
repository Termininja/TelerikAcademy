//Task 4. Write a script that finds the lexicographically smallest
//and largest property in document, window and navigator objects.

//Return the smallest and the largest property in some object
function findProperty(object) {
    var min = 'z';
    var max = 'a';
    for (var p in object) {
        if (p > max) max = p;
        if (p < min) min = p;
    }
    return object + "<br />" + "Smallest property: " + min +
        "<br />" + "Largest property: " + max + "<br />";
}

window.onload = function () {
    var output = document.getElementById('result4');

    //Print the final result;
    output.innerHTML = findProperty(document) + "<br />";
    output.innerHTML += findProperty(window) + "<br />";
    output.innerHTML += findProperty(navigator);
}