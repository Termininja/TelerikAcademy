//Task 3. Write a script that finds the maximal sequence of equal elements in an array.

function maxSequence(array) {
    var maxCount = 0;
    var count = 1;
    var maxElement = null;
    var element = array[0];

    //Finds the maximal sequence of equal elements
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1]) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                maxElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    return new Array(maxCount + 1).join(maxElement).split('');
}