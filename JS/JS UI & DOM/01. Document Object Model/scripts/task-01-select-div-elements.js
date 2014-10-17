function selectDivElements() {
    var elements = document.querySelectorAll('div > div');
    for (var i = 0, len = elements.length; i < len; i++) {
        elements[i].style.background = '#CCC';
        elements[i].innerHTML = 'selected';
    }
}

function selectDivElements() {
    var elements = document.getElementsByTagName('div');
    for (var i = 0, len = elements.length; i < len; i++) {
        if (elements[i].parentNode.nodeName == 'DIV') {
            elements[i].style.background = '#CCC';
            elements[i].innerHTML = 'selected';
        }
    }
}