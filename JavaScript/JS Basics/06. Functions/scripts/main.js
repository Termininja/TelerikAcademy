var lastArray1 = null;
var lastArray2 = null;

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
    var input = document.getElementById('input1').value;
    var result = document.getElementById('result1');
    result.innerHTML = (input === "") ? "" : lastDigitOfInteger(input);
}

function loadTask2() {
    var input = document.getElementById('input2').value;
    var result = document.getElementById('result2');
    result.innerHTML = (input === "") ? "" : reverseNumber(input);
}

function loadTask3() {
    var text = document.getElementById('input31').innerHTML;
    var word = document.getElementById('input32').value;
    var check = document.getElementById('check').checked;
    var result = document.getElementById('result3');

    if (text === "" || word === "") {
        result.innerHTML = "";
    }
    else {
        var wordCount = searchForWord(text, word, check);
        result.innerHTML = (wordCount == 0) ? 'Not found!' : ('Found: ' + wordCount + ' times');
        document.getElementById("input31").innerHTML = text.replace(/<\/?mark>/g, "")
            .replace(new RegExp("(\\b" + word + "\\b)", (check) ? 'g' : 'gi'), "<mark>$1</mark>");
    }
}

function loadTask4(addTag) {
    var tag = document.getElementById('input4').value;
    if (addTag) {
        document.body.appendChild(document.createElement(tag));
    }
    var result = document.getElementById('result4');
    result.innerHTML = (tag === "") ? "" : countPageTags(tag);
}

function loadTask5(input) {
    var number = document.getElementById('input5').value;
    var array = (input) ? lastArray1 : arrayGenerator(30, 0, 6);
    lastArray1 = array;
    document.getElementById('result5').innerHTML =
        (number == 'null') ? '' : '{' + array + '} &nbsp;&#8658;&nbsp; ' +
        countNumberInArray(array, parseInt(number)) + ' times';
}

function loadTask6(input) {
    var index = document.getElementById('input6').value;
    var array = (input) ? lastArray2 : arrayGenerator(15, 0, 6);
    lastArray2 = array;
    document.getElementById('result6').innerHTML =
        (index == 'null') ? '' : '{' + array + '} &nbsp;&#8658;&nbsp; ' +
        checkElementNeighbors(array, parseInt(index));
}

function loadTask7() {
    var length = document.getElementById('input7').value;
    var array = arrayGenerator(parseInt(length), 0, 99);
    var result = firstBigger(array);
    document.getElementById('result7').innerHTML = (length == 'null') ?
        "" : ('{' + array + '} &nbsp;&#8658;&nbsp; ' + ((result === -1) ?
        'Not found!' : ('index ' + result)));
}

//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
    }

    return array;
}