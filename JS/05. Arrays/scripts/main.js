var lastArray = null;

window.onload = function () {
    loadTask1();
    loadTask2();
    loadTask3();
    loadTask4();
    loadTask5();
    loadTask6();
    loadTask7();
}

function loadTask1() {
    var result = multipliedBy5().join(' ');
    console.log(result);
    document.getElementById('result1').innerHTML = result;
}

function loadTask2() {
    var charArray1 = [];
    var charArray2 = [];
    var arrayLength = 10

    for (var i = 0; i < arrayLength; i++) {
        var generator1 = Math.floor(Math.random() * 26);
        var generator2 = Math.floor(Math.random() * 26);
        charArray1[i] = String.fromCharCode(65 + generator1);
        charArray2[i] = String.fromCharCode(65 + generator2);
    }

    var compare = compare2Arrays(charArray1, charArray2);
    var result = document.getElementById('result2');
    result.innerHTML = 'Array1 &nbsp&nbsp&nbsp&nbsp Array2<br />';
    for (var i = 0; i < arrayLength; i++) {
        result.innerHTML += charArray1[i] + ' &nbsp ' + compare[i] +
            '  &nbsp ' + charArray2[i] + '<br />';
    }
}

function loadTask3() {
    var array = arrayGenerator(30, 1, 3);
    document.getElementById('result3').innerHTML = '{' + array +
        '} &nbsp;&#8658;&nbsp; {' + maxSequence(array) + '}';
}

function loadTask4() {
    var array = arrayGenerator(30, 1, 5);
    document.getElementById('result4').innerHTML = '{' + array +
        '} &nbsp;&#8658;&nbsp; {' + maxIncreasingSequence(array) + '}';
}

function loadTask5() {
    var array = arrayGenerator(20, -100, 200);
    document.getElementById('result5').innerHTML = 'array = {'
        + array + '}<br />sortedArray = {' + sortArray(array) + '}';
}

function loadTask6() {
    var array = arrayGenerator(30, 1, 5);
    document.getElementById('result6').innerHTML = '{' + array
        + '} &nbsp;&#8658;&nbsp; ' + mostFrequentNumber(array);
}

function loadTask7(input) {
    var number = document.getElementById('input7').value;
    var array = (input) ? lastArray : arrayGenerator(30, 1, 99);
    lastArray = array;
    array.sort(function (a, b) { return a - b });

    var index = binarySearch(array, number);
    document.getElementById('result7').innerHTML = '{' + array +
        '} &nbsp;&#8658;&nbsp; ' + ((index === -1) ? 'not found!' : index);

}

//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
    }

    return array;
}