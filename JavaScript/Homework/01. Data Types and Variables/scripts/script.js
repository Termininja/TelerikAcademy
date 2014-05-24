var integerVariable;
var floatVariable;
var stringVariable;
var booleanVariable;
var quotedStringVariable;
var undefinedVariable;
var nullVariable = null;
var stringArrowResult = "&#8658;&nbsp;&nbsp;&nbsp; type is ";
var array = [];

window.onload = function () {
    stringVariable = document.getElementById('stringID').value = "Some text";
    quotedStringVariable = document.getElementById('quotedStringID').value = "\"How you doin\'?\", Joey said.";
    booleanVariable = document.getElementById('checkboxID').checked = true;
    setInteger(25);
    setFloat(3.14);
    setElementsInArray();
}

function functionExample() { }

function setElementsInArray() {
    array = [integerVariable, floatVariable, stringVariable, booleanVariable, undefinedVariable, nullVariable];
    var element = document.getElementById('spanArray');
    element.innerHTML = ' = [' + (isNaN(integerVariable) ? "" : array[0] + ', ') +
        (isNaN(floatVariable) ? "" : array[1] + ', ') +
        (stringVariable == "" ? "" : '\"' + array[2] + '"' + ', ') +
        array[3] + ', undefined, null]';
}

//Change the value of integerVariable
function setInteger(value) {
    integerVariable = parseInt(value);
    document.getElementById('spanInteger').innerHTML = (isNaN(integerVariable)) ? "" : (" = " + integerVariable);
    typeOf();
}

//Change the value of floatVariable
function setFloat(value) {
    floatVariable = parseFloat(value);
    document.getElementById('spanFloat').innerHTML = (isNaN(floatVariable)) ? "" : (" = " + floatVariable);
    typeOf();
}

//Change the value of stringVariable
function setString(value) {
    stringVariable = value;
    document.getElementById('spanString').innerHTML = " = \"" + stringVariable + "\"";
    typeOf();
}

//Change the value of quotedStringVariable
function setQuotedString(value) {
    quotedStringVariable = value;
    document.getElementById('spanQuotedString').innerHTML = " = \"" + quotedStringVariable + "\"";
    typeOf();
}

//Change the value of booleanVariable
function setBoolean(value) {
    booleanVariable = value;
    document.getElementById('spanBoolean').innerHTML = " = " + booleanVariable;
    typeOf();
}

//The type of all variables
function typeOf() {
    setElementsInArray();
    type('typeArray', array);
    type('typeInt', integerVariable);
    type('typeFloat', floatVariable);
    type('typeString', stringVariable);
    type('typeQString', quotedStringVariable);
    type('typeBool', booleanVariable);
    type('typeFunction', functionExample);
    type('typeUndefined', undefinedVariable);
    type('typeNull', nullVariable);

    function type(id, object) {
        document.getElementById(id).innerHTML = stringArrowResult + typeof object;
    }
}