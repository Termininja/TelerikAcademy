// Variables
var integerVariable;
var floatVariable;
var stringVariable;
var booleanVariable;
var quotedStringVariable;
var undefinedVariable;
var nullVariable = null;
var arrow = "&#8658;&nbsp;&nbsp;&nbsp;";

// Default values for the all variables
window.onload = function () {
    stringVariable = document.getElementById('stringID').value = "Some text";
    quotedStringVariable = document.getElementById('quotedStringID').value = "\"How you doin\'?\", Joey said.";
    booleanVariable = document.getElementById('checkboxID').checked = true;
    Integer(25);
    Float(3.14);
}

// Change the value of integerVariable
function Integer(value) {
    integerVariable = parseInt(value);
    document.getElementById('spanInteger').innerHTML = (isNaN(integerVariable)) ? "" : (" = " + integerVariable);
    TypeOf();
}

// Change the value of floatVariable
function Float(value) {
    floatVariable = parseFloat(value);
    document.getElementById('spanFloat').innerHTML = (isNaN(floatVariable)) ? "" : (" = " + floatVariable);
    TypeOf();
}

// Change the value of stringVariable
function String(value) {
    stringVariable = value;
    document.getElementById('spanString').innerHTML = " = \"" + stringVariable + "\"";
    TypeOf();
}

// Change the value of quotedStringVariable
function QuotedString(value) {
    quotedStringVariable = value;
    document.getElementById('spanQuotedString').innerHTML = " = \"" + quotedStringVariable + "\"";
    TypeOf();
}

// Change the value of booleanVariable
function Boolean(value) {
    booleanVariable = value;
    document.getElementById('spanBoolean').innerHTML = " = " + booleanVariable;
    TypeOf();
}

// The type of all of variables
function TypeOf() {
    document.getElementById('typeInt').innerHTML = isNaN(integerVariable) ? "" : (arrow + typeof integerVariable);
    document.getElementById('typeFloat').innerHTML = (isNaN(floatVariable) ? "" : (arrow + typeof floatVariable));
    document.getElementById('typeString').innerHTML = arrow + typeof stringVariable;
    document.getElementById('typeQString').innerHTML = arrow + typeof quotedStringVariable;
    document.getElementById('typeBool').innerHTML = arrow + typeof booleanVariable;
    document.getElementById('typeUndefined').innerHTML = arrow + typeof undefinedVariable;
    document.getElementById('typeNull').innerHTML = arrow + typeof nullVariable;
}