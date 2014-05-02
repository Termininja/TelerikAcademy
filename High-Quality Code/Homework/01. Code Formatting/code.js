var theLayer;
var pX = 0;
var pY = 0;

addScroll = false;
b = navigator.appName;

document.onmousemove = mouseMove;
if (b === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
    (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

function mouseMove(evn) {
    if (b === "Netscape") {
        pX = evn.pageX - 5;
        pY = evn.pageY;
        if (document.layers.ToolTip.visibility === 'show') {
            PopTip();
        }
    }
    else {
        pX = event.x - 5;
        pY = event.y;
        if (document.all.ToolTip.style.visibility === 'visible') {
            PopTip();
        }
    }
}

function PopTip() {
    ShowMenu(true, 'ToolTip');

    if (b === "Netscape") {
        if (pX + 120 > window.innerWidth) {
            pX = window.innerWidth - 150;
        }

        theLayer.left = pX + 10;
        theLayer.top = pY + 15;
    }
    else {
        if (theLayer) {
            pX = event.x - 5;
            pY = event.y;

            if (addScroll) {
                pX += document.body.scrollLeft;
                pY += document.body.scrollTop;
            }

            if ((pX + 120) > document.body.clientWidth) {
                pX -= 150;
            }

            theLayer.style.pixelLeft = pX + 10;
            theLayer.style.pixelTop = pY + 15;
        }
    }
}

function ShowMenu(show, menu) {
    if (b === "Netscape") {
        theLayer = document.layers.menu;
        theLayer.visibility = (show) ? 'show' : 'hide';
    }
    else {
        theLayer = document.all.menu;
        theLayer.style.visibility = (show) ? 'visible' : 'hidden';
    }
}

function HideTip() {
    ShowMenu(false, 'ToolTip');
}

function HideMenu1() {
    ShowMenu(false, 'menu1');
}

function HideMenu2() {
    ShowMenu(false, 'menu2');
}

function ShowMenu1() {
    ShowMenu(true, 'menu1');
}

function ShowMenu2() {
    ShowMenu(true, 'menu2');
}