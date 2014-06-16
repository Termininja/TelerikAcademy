//Task 2. Write a function that removes all elements with a given value.
//Attach it to the array class. Read about prototype and how to attach methods.

function removeElementByValue(array, element) {
    Array.prototype.removeElement = function (element) {
        while (this.indexOf(element) >= 0) {
            this.splice(this.indexOf(element), 1);
        }
        return this;
    }
    return array.removeElement(element);
}
