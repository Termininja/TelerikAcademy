/// http://jsbin.com/oBoHiceZ/63/
/// Not work for numbers bigger than 2^53 - 1 = 9 007 199 254 740 991

var keep = 0;
var memory = 0;
var flag = false;
var operator = "";
var base = 10;
var binary = Dec2Bin(0);
var Stack = new Array();
var Display = Calculator.Display;

// Executed when the page is loaded
window.onload = function () {
    LoadFormat(10);
    LoadWord('qword');
    Calculator.Memory.style.visibility = 'hidden';
};

// Keyboard input detection
window.onkeyup = function (e) {
    if (e.shiftKey) {
        if (e.keyCode == 56) Function('*');
        if (e.keyCode == 61 || e.keyCode == 187) Function('+');
        else if (e.keyCode == 57) Parentheses(true);                // Key: ( 
        else if (e.keyCode == 48) Parentheses(false);               // Key: ) 
        else if (e.keyCode == 53) Function('mod');                  // Key: % 
        else if (e.keyCode == 54) Function('xor');                  // Key: ^
        else if (e.keyCode == 55) Function('and');                  // Key: &
        else if (e.keyCode == 188) Function('lsh');                 // Key: <
        else if (e.keyCode == 190) Function('rsh');                 // Key: >
        else if (e.keyCode == 220) Function('or');                  // Key: | 
        else if (e.keyCode == 192) Not();                           // Key: ~
    }
    else {
        if (e.keyCode == 8) Back();                                 // Key: ← (backspace)
        else if (e.keyCode == 27) Clear();                          // Key: Esc
        else if (e.keyCode == 46) ClearEntry();                     // Key: Delete
        else if (e.keyCode == 106) Function('*');
        else if (e.keyCode == 107) Function('+');
        else if (e.keyCode == 48) Num('0');
        else if (e.keyCode == 49) Num('1');
        else if (e.keyCode == 111 || e.keyCode == 191) Function('/');
        else if (e.keyCode == 109 || e.keyCode == 173 || e.keyCode == 189) Function('-');
        else if (e.keyCode == 13 || e.keyCode == 61 || e.keyCode == 187) Function('=');

        else if (base == 16 || base == 10 || base == 8) {
            if (e.keyCode == 50) Num('2');
            else if (e.keyCode == 51) Num('3');
            else if (e.keyCode == 52) Num('4');
            else if (e.keyCode == 53) Num('5');
            else if (e.keyCode == 54) Num('6');
            else if (e.keyCode == 55) Num('7');

            else if (base == 16 || base == 10) {
                if (e.keyCode == 56) Num('8');
                else if (e.keyCode == 57) Num('9');

                else if (base == 16) {
                    if (e.keyCode == 65) Num('A');
                    else if (e.keyCode == 66) Num('B');
                    else if (e.keyCode == 67) Num('C');
                    else if (e.keyCode == 68) Num('D');
                    else if (e.keyCode == 69) Num('E');
                    else if (e.keyCode == 70) Num('F');
                }
            }
        }
    }
}

// Read some input number
function Num(number) {
    if (flag) {
        flag = false;
        keep = 0;
    }

    // Check the length of the number
    var len = Display.value.length;
    if ((base == 16 && len < 16) || (base == 10 && len < 19) || (base == 8 && len < 22) || (base == 2 && len < 63)) {
        Display.value = (keep == 0) ? number : Display.value + number;
    }

    Update(parseInt(Display.value, base));
}

// Functionality for the basic math operations
function Function(operator) {
    flag = true;

    if (operator == '+' || operator == '-') priority = 1;
    else if (operator == '*' || operator == '/' || operator == 'mod') priority = 2;
    else if (operator == "or" || operator == 'xor') priority = 3;
    else if (operator == "and") priority = 4;
    else if (operator == "lsh" || operator == "rsh") priority = 5;
    else if (operator == '=') while (Stack.length > 0) Pop();

    if (Stack.length > 0 && priority <= Stack[0][2]) Pop();
    Push(keep, operator, priority);

    Update(keep);
}

// Parentheses functionality
function Parentheses(p) {
    flag = true;
    if (p) {
        Push(0, '(', 0);
        keep = 0;
    }
    else while (Pop());

    Update(keep);
}

// Push some element in the stack
function Push(keep, operator, priority) {
    Stack.unshift(new Array(keep, operator, priority));
}

// Remove some element from the stack
function Pop() {
    if (Stack.length == 0) return false;

    // Calculate the result
    operator = Stack[0][1];
    var value = Stack[0][0];
    switch (operator) {
        case '+': keep = value + keep; break;
        case '-': keep = value - keep; break;
        case '*': keep = value * keep; break;
        case '/': keep = value / keep; break;
        case 'or': keep = value | keep; break;
        case 'and': keep = value & keep; break;
        case 'xor': keep = value ^ keep; break;
        case 'lsh': keep = value << keep; break;
        case 'rsh': keep = value >> keep; break;
        case 'mod': keep = value % keep; break;
        default: break;
    }
    keep = parseInt(keep);
    Stack.shift();

    return operator != '(';
}

// Functionality for ClearEntry (CE) button
function ClearEntry() {
    flag = true;
    Update(0);
}

// Functionality for Clear (C) button
function Clear() {
    operator = null;
    keep = 0;
    Stack = new Array();
    ClearEntry();
}

// Functionality for logical operator NOT
function Not() {
    Update(~keep);
}

// Bitwise right and left rotations
function Rotate(direction) {
    var rotate = (direction == 'r') ? keep >> 1 : keep << 1;
    Update(rotate);
}

// Change the sign of the value
function Neg() {
    Update(-keep);
}

// Remove the last char from the value
function Back() {
    var len = Display.value.length;
    var result = ((keep > 0 && len > 1) || (keep < 0 && len > 2)) ?
        Display.value.substring(0, len - 1) : 0;

    Update(result);
}

// Memory functionality
function Mem(action) {
    var takeMemory = parseInt(Display.value, base);
    var style = Calculator.Memory.style;
    switch (action) {
        case 'MS':
            // Store the current decimal value in the memory
            memory = keep;
            style.visibility = 'visible';
            break;
        case 'MR':
            // Get and display the current memory value
            takeMemory = memory;
            flag = false;
            break;
        case 'M+':
            // Add the current value to the stored memory
            memory += keep;
            style.visibility = 'visible';
            break;
        case 'M-':
            // Subtract the current value from the stored memory
            memory -= keep;
            style.visibility = 'visible';
            break;
        default:
            // Clear all memory
            memory = 0;
            style.visibility = 'hidden';
            break;
    }
    Update(takeMemory);
}

// Change the current numeral system: Hex, Dec, Oct & Bin
function LoadFormat(value) {
    switch (value) {
        case 16: Hex(true);
            OctBin("oct", false);
            OctBin("bin", false);
            break;
        case 8: Hex(false);
            OctBin("oct", true);
            OctBin("bin", false);
            break;
        case 2: Hex(false);
            OctBin("oct", true);
            OctBin("bin", true);
            break;
        default: Hex(false);
            OctBin("oct", false);
            OctBin("bin", false);
            break;
    }

    Display.value = keep.toString(value).toUpperCase();
    CheckValueLength();
    base = value;

    // Configuration for hexadecimal numeral system
    function Hex(show) {
        var elements = document.getElementsByClassName('blocked transition1');
        for (var i = 0; i < elements.length; ++i) {
            elements[i].style.visibility = show ? 'visible' : 'hidden';
        }

        if (show) {
            var elements = document.getElementsByClassName('blocked letter');
            while (elements.length > 0) {
                elements[0].disabled = false;
                elements[0].className = elements[0].className.replace(/\bblocked\b/, "");
            }
        }
        else {
            var elements = document.getElementsByClassName('letter');
            for (var i = 0; i < elements.length; ++i) {
                elements[i].setAttribute("class", "blocked letter");
                elements[i].disabled = true;
            }
        }
    }

    // Configuration for octal and binary numeral systems
    function OctBin(mode, hide) {
        var elements = document.getElementsByClassName(mode + " transition1");
        for (var i = 0; i < elements.length; ++i) {
            elements[i].style.visibility = hide ? 'hidden' : 'visible';
        }

        if (hide) {
            var elements = document.getElementsByClassName("blocked " + mode + " number");
            while (elements.length > 0) {
                elements[0].disabled = true;
                elements[0].className = elements[0].className.replace(/\bnumber\b/, "");
            }
        }
        else {
            var elements = document.getElementsByClassName("blocked " + mode);
            for (var i = 0; i < elements.length; ++i) {
                elements[i].setAttribute("class", "blocked " + mode + " number");
                elements[i].disabled = false;
            }
        }
    }
}

// Change the current bit entry word: Qword, Dword, Word & Byte
function LoadWord(value) {
    var bitLimit;
    switch (value) {
        case 'dword': bitLimit = 32;
            Word('dword', false);
            Word('word', true);
            Word('byte', true);
            break;
        case 'word': bitLimit = 48;
            Word('dword', false);
            Word('word', false);
            Word('byte', true);
            break;
        case 'byte': bitLimit = 56;
            Word('dword', false);
            Word('word', false);
            Word('byte', false);
            break;
        default:
            Word('dword', true);
            Word('word', true);
            Word('byte', true);
            break;
    }

    // Configuration for bit entry word
    function Word(word, show) {
        var element = document.getElementsByClassName(word);
        for (var i = 0; i < element.length; i++) {
            element[i].style.visibility = show ? 'visible' : 'hidden';
        }
    }

    // Correct the value when bit word is changed
    binary = binary.toString().substr(bitLimit);

    Update(parseInt(binary, 2));
}

// Check the length of the current value
function CheckValueLength() {
    var len = Display.value.length;
    if (len > 50) Style("11px", "32px", "18px");
    else if (len > 42) Style("14px", "28px", "22px");
    else if (len > 34) Style("17px", "24px", "26px");
    else if (len > 26) Style("20px", "20px", "30px");
    else Style("26px", "10px", "40px");

    // Change the font style for some element
    function Style(font, top, height) {
        Display.style.fontSize = font;
        Display.style.paddingTop = top;
        Display.style.height = height;
    }
}

// Convert some decimal number to binary (64bit)
function Dec2Bin(int) {
    var bin;
    if (int >= 0) bin = int.toString(2);
    else bin = (-int - 1).toString(2).replace(/[01]/g, function (d) { return +!+d; });

    while (bin.length < 64) bin = ((int >= 0) ? "0" : "1") + bin;
    return bin;
}

// Change some specific bit from the value
function ChangeBit(bit) {
    binary =
        binary.toString().substr(0, 63 - bit) +
        ((binary[63 - bit] == '1') ? '0' : '1') +
        binary.toString().substr(64 - bit);

    Update(parseInt(binary, 2));
}

// Update the current status of the calculator
function Update(value) {
    Display.value = value.toString(base).toUpperCase();
    keep = parseInt(Display.value, base);
    CheckValueLength();

    // Remove the focus from the last clicked element
    document.activeElement.blur();

    // Prints binary representation of any number
    binary = Dec2Bin(keep);
    for (var i = 0; i < 64; i++) {
        document.getElementById("Bit" + i).innerHTML = binary[63 - i];
    }
}