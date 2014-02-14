var Key = document.Calculator;
var Keep = 0;
var Flag = false;
var Operation = "";
var binary = 0;

window.onload = function () {
    Hex(false);
    OctBin("oct", false);
    OctBin("bin", false);
    Bits('dword', true);
    Bits('word', true);
    Bits('byte', true);
};

function Num(number) {
    if (number > 9) {
        // Do something!
        alert("HEX!");
    }
    else {
        if (Flag) {
            Key.Display.value = number;
            Flag = false;
        }
        else {
            if (Key.Display.value == "0") Key.Display.value = number;
            else Key.Display.value += number;
        }
        DisplayBits();
    }
}
function Function(value) {
    var Display = Key.Display.value;
    if (Flag && Operation != "=");
    else {
        Flag = true;
        if ('+' == Operation) Keep += parseFloat(Display);
        else if ('-' == Operation) Keep -= parseFloat(Display);
        else if ('/' == Operation) Keep /= parseFloat(Display);
        else if ('*' == Operation) Keep *= parseFloat(Display);
        else Keep = parseFloat(Display);
        Key.Display.value = Keep;
        Operation = value;
    }
    DisplayBits();
}
function ClearEntry() {
    Key.Display.value = "0";
    Flag = true;
    DisplayBits();
}
function Clear() {
    Keep = 0;
    Operation = "";
    ClearEntry();
}
function Neg() {
    Key.Display.value = parseFloat(Key.Display.value) * -1;
    DisplayBits();
}
function Back() {
    var value = parseFloat(Key.Display.value).toString();
    if ((Key.Display.value > 0 && value.length > 1) ||
        (Key.Display.value < 0 && value.length > 2)) {
        Key.Display.value = parseFloat(value.substring(0, value.length - 1));
    }
    else Key.Display.value = 0;
    DisplayBits();
}

function ViewFormat(value) {
    switch (value) {
        case 'hex':
            Hex(true);
            OctBin("oct", false);
            OctBin("bin", false);
            break;
        case 'oct':
            Hex(false);
            OctBin("oct", true);
            OctBin("bin", false);
            break;
        case 'bin':
            Hex(false);
            OctBin("oct", true);
            OctBin("bin", true);
            var bynaryText = binary.replace(/^0+/, '');
            if (bynaryText.length > 12) {
                Key.Display.style.fontSize = "11px";
                Key.Display.style.paddingTop = "32px";
                Key.Display.style.height = "18px";
                Key.Display.value = bynaryText;
            }
            break;
        default:
            Hex(false);
            OctBin("oct", false);
            OctBin("bin", false);
            break;
    }
}
function ViewBits(value) {
    switch (value) {
        case 'dword':
            Bits('dword', false);
            Bits('word', true);
            Bits('byte', true);
            break;
        case 'word':
            Bits('dword', false);
            Bits('word', false);
            Bits('byte', true);
            break;
        case 'byte':
            Bits('dword', false);
            Bits('word', false);
            Bits('byte', false);
            break;
        default:
            Bits('dword', true);
            Bits('word', true);
            Bits('byte', true);
            break;
    }
}
function Hex(show) {
    if (show) {
        var elements = document.getElementsByClassName('blocked letter');
        while (elements.length > 0) {
            elements[0].disabled = false;
            elements[0].className = elements[0].className.replace(/\bblocked\b/, "");
        }

        var elements2 = document.getElementsByClassName('blocked transition1');
        for (var i = 0; i < elements2.length; ++i) {
            elements2[i].style.visibility = 'visible';
        }
    }
    else {
        var elements = document.getElementsByClassName('letter');
        for (var i = 0; i < elements.length; ++i) {
            elements[i].setAttribute("class", "blocked letter");
            elements[i].disabled = true;
        }

        var elements2 = document.getElementsByClassName('blocked transition1');
        for (var i = 0; i < elements2.length; ++i) {
            elements2[i].style.visibility = 'hidden';
        }
    }
}
function OctBin(mode, hide) {
    if (hide) {
        var elements = document.getElementsByClassName("blocked " + mode + " number");
        while (elements.length > 0) {
            elements[0].disabled = true;
            elements[0].className = elements[0].className.replace(/\bnumber\b/, "");
        }
        var elements2 = document.getElementsByClassName(mode + " transition1");
        for (var i = 0; i < elements2.length; ++i) {
            elements2[i].style.visibility = 'hidden';
        }
    }
    else {
        var elements = document.getElementsByClassName("blocked " + mode);
        for (var i = 0; i < elements.length; ++i) {
            elements[i].setAttribute("class", "blocked " + mode + " number");
            elements[i].disabled = false;
        }
        var elements2 = document.getElementsByClassName(mode + " transition1");
        for (var i = 0; i < elements2.length; ++i) {
            elements2[i].style.visibility = 'visible';
        }
    }
}
function Bits(word, show) {
    var element = document.getElementsByClassName(word);
    for (var i = 0; i < element.length; i++) {
        element[i].style.visibility = show ? 'visible' : 'hidden';
    }
}

function DisplayBits() {
    var inputs = document.getElementsByTagName("input");

    var n = parseInt((Key.Display.value).toString());
    binary = Dec2Bin(n);

    for (var i = 0; i < binary.length; i++) {
        document.getElementsByName("Bit" + i)[0].value = binary[63 - i];
    }
}

function Dec2Bin(int) {
    var bin;
    if (int >= 0) bin = int.toString(2);
    else bin = (-int - 1).toString(2).replace(/[01]/g, function (d) { return +!+d; });
    while (bin.length < 64) bin = ((int >= 0) ? "0" : "1") + bin;
    return bin;
}
