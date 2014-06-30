$(document).ready(function () {
    var canvas = document.getElementById('canvas-container');
    var context = canvas.getContext('2d');

    var drawingShape = (function () {
        function rect(x, y, w, h) {
            context.beginPath();
            context.strokeRect(x, y, w, h);
        }

        function circle(x, y, r) {
            context.beginPath();
            context.arc(x, y, r, 0, 2 * Math.PI);
            context.stroke();
        }

        function line(x1, y1, x2, y2) {
            context.beginPath();
            context.moveTo(x1, y1);
            context.lineTo(x2, y2);
            context.stroke();
        }

        return {
            rect: rect,
            circle: circle,
            line: line
        }
    })();

    drawingShape.rect(100, 50, 150, 50);
    drawingShape.circle(250, 250, 100);
    drawingShape.line(500, 50, 400, 350);
});