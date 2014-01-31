document.cestatus = 0;
var Key = document.Calculator;
var Keep = 0;
var Power = false;
var LastResult = null;
var NotUsed = 0;
var Factor = Math.PI / 180;
var Flag = false;
var Operation = "";
var ClickSound = "click.mp3";

function Num(number) {
    if (Power) {
        PlaySound(ClickSound);
        if (Flag) {
            Key.Display.value = number;
            Flag = false;
        }
        else {
            if (Key.Display.value == "0") Key.Display.value = number;
            else Key.Display.value += number;
        }
    }
}
function Function(value) {
    if (Power) {
        PlaySound(ClickSound);
        var Display = Key.Display.value;
        if (Flag && Operation != "=");
        else {
            Flag = true;
            if ('+' == Operation) Keep += parseFloat(Display);
            else if ('-' == Operation) Keep -= parseFloat(Display);
            else if ('/' == Operation) Keep /= parseFloat(Display);
            else if ('*' == Operation) Keep *= parseFloat(Display);
            else if ('pow' == Operation) Keep = Math.pow(Keep, parseFloat(Display));
            else if ('root' == Operation) Keep = Math.pow(Keep, 1 / parseFloat(Display));
            else if ('log' == Operation) Keep = Math.log(Keep) / Math.log(parseFloat(Display));
            else Keep = parseFloat(Display);
            Key.Display.value = Keep;
            Operation = value;
        }
    }
}
function Decimal() {
    if (Power) {
        PlaySound(ClickSound);
        var curDisplay = Key.Display.value;
        if (Flag) {
            curDisplay = "0.";
            Flag = false;
        }
        else {
            if (curDisplay.indexOf(".") == -1) curDisplay += ".";
        }
        Key.Display.value = curDisplay;
    }
}
function ClearEntry() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = "0";
        Flag = true;
    }
}
function Clear() {
    if (Power) {
        Keep = 0;
        Operation = "";
        ClearEntry();
    }
}
function Neg() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = parseFloat(Key.Display.value) * -1;
    }
}
function Percent() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = (parseFloat(Key.Display.value) / 100) * parseFloat(Keep);
    }
}
function Sin() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.sin(Factor * parseFloat(Key.Display.value));
    }
}
function Cos() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.cos(Factor * parseFloat(Key.Display.value));
    }
}
function Tan() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.tan(Factor * parseFloat(Key.Display.value));
    }
}
function Log() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.log(parseFloat(Key.Display.value));
    }
}
function Rec() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = 1 / parseFloat(Key.Display.value);
    }
}
function Fact() {
    if (Power) {
        PlaySound(ClickSound);
        var f = 1;
        for (var i = 2; i <= parseFloat(Key.Display.value) ; i++) f *= i;
        Key.Display.value = f;
    }
}
function Sqrt() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.sqrt(parseFloat(Key.Display.value));
    }
}
function Pi() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.PI;
    }
}
function X2() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.pow(parseFloat(Key.Display.value), 2);
    }
}
function X3() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.pow(parseFloat(Key.Display.value), 3);
    }
}
function Exp() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.exp(parseFloat(Key.Display.value));
    }
}
function Root3() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.pow(parseFloat(Key.Display.value), 1 / 3);
    }
}
function TenX() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.pow(10, parseFloat(Key.Display.value));
    }
}
function Back() {
    if (Power) {
        PlaySound(ClickSound);
        var value = parseFloat(Key.Display.value).toString();
        if ((Key.Display.value > 0 && value.length > 1) ||
            (Key.Display.value < 0 && value.length > 2)) {
            Key.Display.value = parseFloat(value.substring(0, value.length - 1));
        }
        else Key.Display.value = 0;
    }
}
function Log10() {
    if (Power) {
        PlaySound(ClickSound);
        Key.Display.value = Math.log(parseFloat(Key.Display.value)) / Math.LN10;
    }
}

function Angle(value) {
    switch (value) {
        case 'deg': Factor = Math.PI / 180; break;
        case 'grad': Factor = 9 * Math.PI / 1800; break;
        default: Factor = 1; break;
    }
}

function Switch() {
    if (!Power) {
        Power = true;
        setTimeout(function () {
            Clock('off');
        }, 1000);
        setTimeout(function () {
            Keypad();
            Opacity("1");
        }, 2000);
        setTimeout(function () {
            BackColor('rgba(188, 205, 149, 1.00)');
        }, 3000);
        setTimeout(function () {
            Key.Display.value = 0;
        }, 4000);
    }
    else {
        setTimeout(function () {
            Key.Display.value = null;
        }, 500);
        setTimeout(function () {
            BackColor('rgba(188, 205, 149, 0.10)');
        }, 1500);
        setTimeout(function () {
            Opacity("0");
            Keypad();
            Key.Display.value = null;
            Power = false;
        }, 2500);
        setTimeout(function () {
            Clock('on');
        }, 3500);
    }
    setTimeout(function () {
        State();
    }, 10000);
}
function Opacity(value) {
    var elements = document.getElementsByClassName('hide');
    for (var i = 0; i < elements.length; i++) {
        elements[i].style.opacity = value;
    }
}
function BackColor(color) {
    var element = document.getElementById('display');
    element.style.backgroundColor = color;
}
function Keypad() {
    if (document.cestatus === 0) {
        document.getElementById('box').style.display = "block";
        document.cestatus = 1;
    } else {
        document.getElementById('box').style.display = "none";
        document.cestatus = 0;
    }
}
function Clock(value) {
    var el = document.getElementById('clock');
    if (value == "on") {
        el.style.fontSize = "16px";
        el.style.textAlign = "center";

        var dn = "AM";
        if ((new Date()).getHours() > 12) dn = "PM";

        var d = (new Date() + '').split(' ');
        Key.DateTime.value = [d[2], d[1], d[3] + " (" + d[0] + ")", d[4]].join(' ') + " " + dn;
        if (!Power) setTimeout(function () {
            Clock('on');
        }, 10);
    }
    else {
        el.style.fontSize = "21px";
        el.style.textAlign = "right";
        Key.DateTime.value = null;
    }
}

function PlaySound(file, hidden) {
    var source = document.createElement('source');
    source.setAttribute('src', file);

    var sound = document.createElement('audio');
    sound.appendChild(source);
    if (hidden) { sound.load(); }
    else { sound.play(); }
}

function State() {
    if ((document.cestatus === 0 && Power) ||
        (document.cestatus == 1 && !Power)) {
        Keypad();
    }
}

function CheckState() {
    if (Power) {
        if (Key.Display.value == LastResult) {
            NotUsed++;
        }
        else {
            LastResult = Key.Display.value;
            NotUsed = 0;
        }

        if (NotUsed > 6) Switch();
    }

    setTimeout(function () {
        CheckState();
    }, 10000);
}

window.onload = function () {
    PlaySound(ClickSound, true);
    Clock('on');
    CheckState();
};