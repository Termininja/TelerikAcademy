//Task 5. Write a script to sort the elements in an array in increasing order.
//Use the "selection sort" algorithm: Find the smallest element, move it at the first
//position, find the smallest from the rest, move it at the second position, etc.

function sortArray(array) {
    for (var i = 0; i < array.length - 1; i++) {
        //Find the smallest element
        var minElement = array[i];
        var minIndex = i;
        for (var j = i + 1; j < array.length; j++) {
            if (array[j] < minElement) {
                minElement = array[j];
                minIndex = j;
            }
        }

        //Swap the current element with the smallest element
        var tempElement = array[i];
        array[i] = minElement;
        array[minIndex] = tempElement;
    }

    return array;
}