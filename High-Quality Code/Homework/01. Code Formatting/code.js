/* Code refactoring:
 *
 * All missing semicolons are created
 * Defined are all undefined variables
 * Fixed are mixed spaces and tabs
 * Removed are some unnecessary semicolons
 * Removed are some unused variables
 * Eval is removed because it can be harmful
 * All menu functions are put in one method because of code repetition
 */

var theLayer;
var pX = 0;
var pY = 0;
var addScroll = false;
var browser = navigator.appName;

document.onmousemove = mouseMove;
if (browser === "Netscape") {
    document.captureEvents(Event.MOUSEMOVE);
}

if ((navigator.userAgent.indexOf('MSIE 5') > 0) ||
    (navigator.userAgent.indexOf('MSIE 6')) > 0) {
    addScroll = true;
}

function mouseMove(evn) {
    if (browser === "Netscape") {
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

    if (browser === "Netscape") {
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
    if (browser === "Netscape") {
        theLayer = document.layers[menu];
        theLayer.visibility = (show) ? 'show' : 'hide';
    }
    else {
        theLayer = document.all[menu];
        theLayer.style.visibility = (show) ? 'visible' : 'hidden';
    }
}