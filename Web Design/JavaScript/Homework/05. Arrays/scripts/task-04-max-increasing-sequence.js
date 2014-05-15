//Task 4. Write a script that finds the maximal increasing sequence in an array.

function maxIncreasingSequence(array) {
    var count = 1;
    var maxCount = count;
    var element = array[0];
    var minElement = element;

    //Finds the maximal increasing sequence
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1] + 1) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                minElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    //Create array from searched elements
    var result = [];
    for (var i = 0; i < maxCount; i++) {
        result[i] = i + minElement;
    }

    return result;
}