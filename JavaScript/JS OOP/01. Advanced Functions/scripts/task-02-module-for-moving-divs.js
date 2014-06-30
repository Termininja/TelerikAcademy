$(document).ready(function () {
    var movingShapes = (function () {
        //Add new moving div element to the DOM
        function add(shape) {
            var element = document.createElement('div');

            element.innerHTML += 'div';
            element.style.textAlign = 'center';
            element.style.width = random.getNumber(20, 100) + 'px';
            element.style.height = random.getNumber(20, 100) + 'px';
            element.style.backgroundColor = random.getColor();
            element.style.color = random.getColor();
            element.style.border = random.getNumber(1, 20) + 'px solid ' + random.getColor();
            element.style.position = 'absolute';

            document.getElementById('wrapper').appendChild(element);

            if (shape == 'ellipse') {
                var x = 100;
                var y = 100;
                var alpha = 0;
                var timer = setInterval(function () {
                    alpha++;
                    if (alpha === 360) alpha = 0;
                    var left = x + Math.cos((2 * 3.14 / 180) * (alpha)) * 100;
                    var right = y + Math.sin((2 * 3.14 / 180) * (alpha)) * 100;

                    element.style.left = left + 'px';
                    element.style.top = right + 'px';
                }, 30);
            }
            else if (shape == 'rect') {
                var x = 100;
                var y = 100;
                var direction = 0;
                var timer = setInterval(function () {
                    if (direction > 3) direction = 0;

                    switch (direction) {
                        case 0: x += 5; if (x > 500) direction++; break;
                        case 1: y += 5; if (y > 300) direction++; break;
                        case 2: x -= 5; if (x < 100) direction++; break;
                        case 3: y -= 5; if (y < 100) direction++; break;
                    }

                    element.style.left = x + 'px';
                    element.style.top = y + 'px';
                }, 50);
            }
        }

        //The module
        return {
            add: add
        };

    })();

    //Generate random number and color
    var random = (function () {
        function getNumber(min, max) {
            return Math.floor(Math.random() * (max - min + 1)) + min;
        }

        function getColor() {
            var red = Math.floor(Math.random() * 256);
            var green = Math.floor(Math.random() * 256);
            var blue = Math.floor(Math.random() * 256);

            return 'rgb(' + red + ',' + green + ',' + blue + ')';
        }

        return {
            getNumber: getNumber,
            getColor: getColor
        };
    })();

    //Add element with rectangular movement
    movingShapes.add("rect");

    //Add element with ellipse movement
    movingShapes.add("ellipse");
});



// * The module should generate random background, font and border colors for the div element
// * All the div elements are with the same width and height
//* The movements of the div nodes can be either circular or rectangular
//* The elements should be moving all the time
