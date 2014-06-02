//**Task 01.** Write a script that selects all the div nodes that are directly inside other div elements
// * Create a function using `querySelectorAll()`
// * Create a function using `getElementsByTagName()`

function selectDivElements() {
    var elements = document.querySelectorAll('div > div');
    for (var i = 0, len = elements.length; i < len; i++) {
        elements[i].style.background = 'red';
        elements[i].innerHTML = 'selected';
    }
}

function selectDivElements() {
    var elements = document.getElementsByTagName('div');
    for (var i = 0, len = elements.length; i < len; i++) {
        if (elements[i].parentNode.nodeName == 'DIV') {
            elements[i].style.background = 'red';
            elements[i].innerHTML = 'selected';
        }
    }
}

//**Task 02.** Create a function that gets the value of <input type="text">
//and prints its value to the console
function getValue() {
    var elements = document.getElementsByTagName('input');
    for (var i = 0, len = elements.length; i < len; i++) {
        if (elements[i].type == 'text') {
            console.log(elements[i].value);
        }
    }
}

//**Task 03.** Crеate a function that gets the value of <input type="color">
//and sets the background of the body to this value
function changeBackgroud(value) {
    document.body.style.background = value;
}

//**Task 04\*.** Write a script that shims `querySelector` and
//`querySelectorAll` in older browsers
