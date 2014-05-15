//Task 6. Write a program that finds the most frequent number in an array.

function mostFrequentNumber(array) {
    var maxCount = 0;
    var count = 1;
    var mostFrequentElement = null;
    var element = array[0];

    //Sort the elements in array in increasing order
    array.sort(function (a, b) { return a - b });

    //Finds the most frequent number in array
    for (var i = 1; i < array.length; i++) {
        if (array[i] === array[i - 1]) {
            count++;
            if (count > maxCount) {
                maxCount = count;
                mostFrequentElement = element;
            }
        }
        else {
            element = array[i];
            count = 1;
        }
    }

    return mostFrequentElement + ' (' + maxCount + ' times)';
}