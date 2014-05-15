//Task 2. Write a script that compares two char arrays lexicographically (letter by letter).

function compare2Arrays(array1, array2) {
    var result = [];
    for (var i = 0; i < array1.length; i++) {
        if (array1[i] === array2[i]) result[i] = '=';
        else if (array1[i] > array2[i]) result[i] = '>';
        else result[i] = '<';
    }

    return result;
}

