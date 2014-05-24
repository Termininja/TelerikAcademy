//Task 3. Write a function that makes a deep copy of an object.
//The function should work for both primitive and reference types.

function deepCopy(object) {
    Object.prototype.copy = function () {
        var result = {};
        for (var property in this) {
            result[property] = (typeof this[property] === 'object') ?
                deepCopy(this[property]) : this[property];
        }
        return result;
    }

    return object.copy();
}
