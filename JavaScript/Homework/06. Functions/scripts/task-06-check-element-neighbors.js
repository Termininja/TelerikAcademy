//Task 6. Write a function that checks if the element at given position in 
//given array of integers is bigger than its two neighbors (when such exist).

function checkElementNeighbors(array, i) {
    return (array[i] > array[i - 1] && array[i] > array[i + 1] &&
        i > 0 && i < array.length - 1) ? true : false;
}