//Task 7. Write a program that finds the index of given element
//in a sorted array of integers by using the binary search algorithm.

function binarySearch(sortedArray, element) {
    var min = 0;
    var max = sortedArray.length - 1;

    //Finds the index of the given element in array
    while (max > min) {
        var mid = Math.floor((min + max) / 2);
        if (element <= sortedArray[mid]) max = mid;
        else min = mid + 1;

        //The result
        if (min == max && sortedArray[min] == element) return min;
        else if (min == max) return -1;
    }
}
