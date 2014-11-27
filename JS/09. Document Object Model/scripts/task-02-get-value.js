function getValue() {
    var elements = document.getElementsByTagName('input');
    for (var i = 0, len = elements.length; i < len; i++) {
        if (elements[i].type == 'text') {
            console.log(elements[i].value);
        }
    }

    document.getElementById('output2').innerHTML = 'Press F12 and go to Console.';
}