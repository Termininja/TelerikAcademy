$(document).ready(function () {
    var alpha = 0;
    var direction = 0;
    var x = 100;
    var y = 100;

    var movingShapes = (function () {
        //Add new moving div element to the DOM
        function add(shape) {
            var element = document.createElement('div');
            element.innerHTML += shape;
            element.style.textAlign = 'center';
            element.style.width = rand.number(40, 100) + 'px';
            element.style.height = rand.number(20, 40) + 'px';
            element.style.backgroundColor = rand.color();
            element.style.color = rand.color();
            element.style.border = rand.number(1, 20) + 'px solid ' + rand.color();
            element.style.position = 'absolute';
            document.getElementById('wrapper').appendChild(element);

            function animation() {
                if (shape == 'ellipse') {
                    if (alpha++ === 360) alpha = 0;
                    element.style.borderRadius = '500px';
                    element.style.left = 100 + Math.cos(Math.PI * alpha / 90) * 100 + 'px';
                    element.style.top = 100 + Math.sin(Math.PI * alpha / 90) * 100 + 'px';
                }
                else if (shape == 'rect') {
                    if (direction > 3) direction = 0;
                    switch (direction) {
                        case 0: x++; if (x > 500) direction++; break;
                        case 1: y++; if (y > 300) direction++; break;
                        case 2: x--; if (x < 100) direction++; break;
                        case 3: y--; if (y < 100) direction++; break;
                    }
                    element.style.left = x + 'px';
                    element.style.top = y + 'px';
                }

                requestAnimationFrame(animation)
            }

            animation();
        }

        return {
            add: add
        };

    })();

    //Generate random number and color
    var rand = (function () {
        function number(min, count) {
            return Math.floor(Math.random() * count + min);
        }

        function color() {
            return 'rgb(' + rand.number(0, 256) + ',' + rand.number(0, 256) + ',' + rand.number(0, 256) + ')';
        }

        return {
            number: number,
            color: color
        };
    })();

    //Add element with rectangular movement
    movingShapes.add("rect");

    //Add element with ellipse movement
    movingShapes.add("ellipse");
});