//Task 7. Write a function that returns the index of the first element bigger than its
//neighbors, or -1, if there’s no such element. Use the function from the previous exercise.

function firstBigger(array) {
    for (var i in array) {
        if (checkElementNeighbors(array, parseInt(i))) return i;
    }

    return -1;
}