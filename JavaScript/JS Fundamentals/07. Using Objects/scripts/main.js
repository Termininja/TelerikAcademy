var lastArray = null;

window.onload = function () {
    loadTask1();
    loadTask2();
    loadTask3();
    loadTask4();
    loadTask5();
    loadTask6();
}

function loadTask1() {
    //Creates 6 points
    var P1 = new Point(
        parseFloat(document.getElementById('input1p1x').value),
        parseFloat(document.getElementById('input1p1y').value));
    var P2 = new Point(
        parseFloat(document.getElementById('input1p2x').value),
        parseFloat(document.getElementById('input1p2y').value));
    var P3 = new Point(
        parseFloat(document.getElementById('input1p3x').value),
        parseFloat(document.getElementById('input1p3y').value));
    var P4 = new Point(
        parseFloat(document.getElementById('input1p4x').value),
        parseFloat(document.getElementById('input1p4y').value));
    var P5 = new Point(
        parseFloat(document.getElementById('input1p5x').value),
        parseFloat(document.getElementById('input1p5y').value));
    var P6 = new Point(
        parseFloat(document.getElementById('input1p6x').value),
        parseFloat(document.getElementById('input1p6y').value));

    //Creates 3 lines
    var L1 = new Line(P1, P2);
    var L2 = new Line(P3, P4);
    var L3 = new Line(P5, P6);

    //Calculates segment's length
    var segment1 = parseFloat(segment('segment1', P1, P2));
    var segment2 = parseFloat(segment('segment2', P3, P4));
    var segment3 = parseFloat(segment('segment3', P5, P6));

    function segment(segment, point1, point2) {
        var result = parseFloat(getDistance(point1, point2)).toFixed(2);
        document.getElementById(segment).innerHTML =
            (isNaN(result)) ? "" : (segment + ' = ' + result);
        return result;
    }

    //Check if the three segment lines can form a triangle
    document.getElementById('result1').innerHTML =
        (isNaN(segment1) || isNaN(segment2) || isNaN(segment3)) ?
        "" : (checkForTriangle(segment1, segment2, segment3) ?
        'These hree segment lines can form a triangle!' :
        'These hree segment lines can not form a triangle!');
}

function loadTask2(input) {
    var element = document.getElementById('input2').value;
    var array = (input) ? lastArray : arrayGenerator(20, 0, 5);
    lastArray = (input) ? lastArray : array;

    document.getElementById('result2').innerHTML =
    (element == "null") ? '' : '{' + array + '} &nbsp;&#8658;&nbsp; {' +
     removeElementByValue(array, parseInt(element)) + '}';
}

function loadTask3(press) {
    var result1 = document.getElementById('result31');
    var result2 = document.getElementById('result32');

    //The first object is created
    object1 = { name: 'Ivan', age: 23, hair: { color: 'brown', type: 'curly' } };
    result1.innerHTML = 'object1 = {name: "Ivan", age: 23, hair: {color: "brown", type: "curly"}}' +
        ' <span class="blue">was created</span>';

    if (press) {
        //Copy of the first object is created
        object2 = deepCopy(object1);
        result2.innerHTML = '<br /><span class="blue">Created is</span> object2 = deepCopy(object1)';

        //Change some values to check the copy
        object1.hair.color = 'red';
        result2.innerHTML += '<br /><br />Hair color of object1 was changed to "red"';
        result2.innerHTML += '<br /><br /><span class="red">Press F12 and go to "Console" to check both objects</span>';

        console.clear();
        console.info('object1');
        console.log(object1);
        console.info('object2');
        console.log(object2);
    }
    else {
        result2.innerHTML = "";
    }
}

function loadTask4() {
    var object = { firstname: 'Ivan', lastname: 'Petrov', age: 33 };
    document.getElementById('result41').innerHTML =
        'object = {firstname: "Ivan", lastname: "Petrov", age: 33}' +
        ' <span class="blue">was created</span>';

    var property = document.getElementById('input4').value;
    document.getElementById('result42').innerHTML =
       (property == '') ? '' : (property + (hasProperty(object, property) ?
       ' is' : ' is not') + ' property of this object!');
}

function loadTask5() {
    var persons = [
        {
            firstname: document.getElementById('input5f1').value,
            lastname: document.getElementById('input5l1').value,
            age: parseInt(document.getElementById('input5a1').value)
        },
        {
            firstname: document.getElementById('input5f2').value,
            lastname: document.getElementById('input5l2').value,
            age: parseInt(document.getElementById('input5a2').value)
        },
        {
            firstname: document.getElementById('input5f3').value,
            lastname: document.getElementById('input5l3').value,
            age: parseInt(document.getElementById('input5a3').value)
        },
        {
            firstname: document.getElementById('input5f4').value,
            lastname: document.getElementById('input5l4').value,
            age: parseInt(document.getElementById('input5a4').value)
        },
    ];

    document.getElementById('result5').innerHTML =
        'The youngest person is: ' + findYoungest(persons);
}

function loadTask6(press) {
    var persons = [
        {
            firstname: document.getElementById('input6f1').value,
            lastname: document.getElementById('input6l1').value,
            age: parseInt(document.getElementById('input6a1').value)
        },
        {
            firstname: document.getElementById('input6f2').value,
            lastname: document.getElementById('input6l2').value,
            age: parseInt(document.getElementById('input6a2').value)
        },
        {
            firstname: document.getElementById('input6f3').value,
            lastname: document.getElementById('input6l3').value,
            age: parseInt(document.getElementById('input6a3').value)
        },
        {
            firstname: document.getElementById('input6f4').value,
            lastname: document.getElementById('input6l4').value,
            age: parseInt(document.getElementById('input6a4').value)
        },
        {
            firstname: document.getElementById('input6f5').value,
            lastname: document.getElementById('input6l5').value,
            age: parseInt(document.getElementById('input6a5').value)
        },
        {
            firstname: document.getElementById('input6f6').value,
            lastname: document.getElementById('input6l6').value,
            age: parseInt(document.getElementById('input6a6').value)
        },
    ];

    var groupKey = document.getElementById('input6').value;
    var groupedByKey = groupBy(persons, groupKey);
    var result = document.getElementById('result6');
    if (press) {
        console.clear();
        console.info('persons');
        console.log(groupedByKey);
        result.innerHTML =
       '<br /><span class="red">Press F12 and go to "Console" to check grouped elements</span>';
    }
    else {
        result.innerHTML = "";
    }
}

//Generate an array of random integers
function arrayGenerator(len, start, count) {
    var array = [];
    for (var i = 0; i < len; i++) {
        array[i] = Math.floor(Math.random() * count + start);
    }

    return array;
}