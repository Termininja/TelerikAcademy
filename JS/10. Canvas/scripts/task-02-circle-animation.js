window.onload = function () {
    var canvas = document.getElementById('task2');
    var context = canvas.getContext('2d');
    var x = 100;
    var y = 400;
    var r = 15;
    var speed = 3;
    var direction = 'ur';

    function animation() {
        context.clearRect(0, 0, canvas.width, canvas.height);
        context.fillStyle = '#FFCC99';
        context.strokeStyle = '#CCCC00';

        context.beginPath();
        context.arc(x, y, r, 0, 2 * Math.PI);
        context.stroke();
        context.fill();

        switch (direction) {
            case 'ur': x += speed; y -= speed; break;
            case 'ul': x -= speed; y -= speed; break;
            case 'dr': x += speed; y += speed; break;
            case 'dl': x -= speed; y += speed; break;
            default: break;
        }

        if (y - r < 0) {
            direction = (direction == 'ur') ? 'dr' : 'dl';
        }
        if (y + r > canvas.height) {
            direction = (direction == 'dr') ? 'ur' : 'ul';
        }
        if (x - r < 0) {
            direction = (direction == 'ul') ? 'ur' : 'dr';
        }
        if (x + r > canvas.width) {
            direction = (direction == 'dr') ? 'dl' : 'ul';
        }

        requestAnimationFrame(animation);
    }
    animation();
}