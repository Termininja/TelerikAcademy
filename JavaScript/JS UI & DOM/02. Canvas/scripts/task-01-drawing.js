window.onload = function Drawing() {
    var canvas = document.getElementById('task1');
    var context = canvas.getContext('2d');

    context.strokeStyle = '#366974';
    context.fillStyle = '#90CAD7';
    context.lineWidth = 2;

    //head
    context.save();
    context.beginPath();
    context.scale(1.1, 1);
    context.arc(200, 200, 50, 0, 2 * Math.PI);
    context.stroke();
    context.fill();

    //eyes
    context.beginPath();
    context.scale(1.4, 1);
    context.arc(122, 180, 6, 0, 2 * Math.PI);
    context.stroke();
    context.beginPath();
    context.arc(150, 180, 6, 0, 2 * Math.PI);
    context.stroke();

    //pupil
    context.beginPath();
    context.fillStyle = '#366974';
    context.scale(1, 2.5);
    context.arc(120, 72, 2, 0, 2 * Math.PI);
    context.fill();
    context.beginPath();
    context.arc(148, 72, 2, 0, 2 * Math.PI);
    context.fill();
    context.restore();

    //nose
    context.beginPath();
    context.moveTo(210, 180);
    context.lineTo(197, 210);
    context.lineTo(210, 210);
    context.stroke();

    //mouth
    context.beginPath();
    context.save();
    context.rotate(10 * Math.PI / 180);
    context.scale(1, 0.3);
    context.arc(245, 625, 20, 0, 2 * Math.PI);
    context.restore();
    context.stroke();

    //hat
    context.beginPath();
    context.fillStyle = '#396693';
    context.strokeStyle = '#333';
    context.save();
    context.scale(6, 1);
    context.arc(36, 155, 10, 0, 2 * Math.PI);
    context.restore();
    context.fill();
    context.stroke();

    context.beginPath();
    context.rect(186, 87, 62, 60);
    context.fill();
    context.stroke();

    context.beginPath();
    context.save();
    context.scale(2.5, 1);
    context.arc(86.8, 88, 12.5, 0, 2 * Math.PI);
    context.restore();
    context.fill();
    context.stroke();

    context.beginPath();
    context.save();
    context.scale(2.5, 1);
    context.arc(86.8, 144, 12.5, 0, Math.PI);
    context.restore();
    context.fill();
    context.stroke();

    //bike
    context.fillStyle = '#90CAD7';
    context.strokeStyle = '#366974';

    context.beginPath();
    context.arc(130, 450, 60, 0, 2 * Math.PI);
    context.fill();
    context.stroke();
    context.beginPath();
    context.arc(360, 450, 60, 0, 2 * Math.PI);
    context.fill();
    context.stroke();

    context.beginPath();
    context.moveTo(130, 450);
    context.lineTo(190, 370);
    context.lineTo(330, 370);
    context.lineTo(230, 450);
    context.closePath();
    context.stroke();

    context.beginPath();
    context.moveTo(360, 450);
    context.lineTo(320, 340);
    context.lineTo(350, 300);
    context.stroke();
    context.beginPath();
    context.moveTo(320, 340);
    context.lineTo(280, 350);
    context.stroke();

    context.beginPath();
    context.moveTo(230, 450);
    context.lineTo(177, 340);
    context.stroke();
    context.beginPath();
    context.moveTo(150, 340);
    context.lineTo(200, 340);
    context.stroke();

    context.beginPath();
    context.arc(230, 450, 15, 0, 2 * Math.PI);
    context.stroke();
    context.beginPath();
    context.moveTo(219, 439);
    context.lineTo(206, 424);
    context.stroke();
    context.beginPath();
    context.moveTo(252, 476);
    context.lineTo(239, 461);
    context.stroke();

    //house
    context.fillStyle = '#975B5B';
    context.strokeStyle = 'black';
    context.lineWidth = '3'

    context.beginPath();
    context.rect(500, 220, 250, 200);
    context.fill();
    context.beginPath();
    context.moveTo(500, 217);
    context.lineTo(625, 70);
    context.lineTo(750, 217);
    context.closePath();
    context.fill();

    //chimney
    context.lineWidth = '5'
    context.beginPath();
    context.rect(670, 100, 23, 70);
    context.stroke();
    context.fill();
    context.beginPath();
    context.rect(670, 170, 23, 10);
    context.fill();
    context.beginPath();
    context.save();
    context.scale(1, 0.3);
    context.arc(681, 335, 11.7, 0, 2 * Math.PI);
    context.restore();
    context.stroke();
    context.fill();

    //windows
    context.beginPath();
    context.fillStyle = '#000';
    context.rect(520, 245, 45, 30);
    context.rect(568, 245, 45, 30);
    context.rect(637, 245, 45, 30);
    context.rect(685, 245, 45, 30);
    context.rect(520, 278, 45, 30);
    context.rect(568, 278, 45, 30);
    context.rect(637, 278, 45, 30);
    context.rect(685, 278, 45, 30);
    context.rect(637, 330, 45, 30);
    context.rect(685, 330, 45, 30);
    context.rect(637, 363, 45, 30);
    context.rect(685, 363, 45, 30);
    context.fill();

    //door
    context.lineWidth = '3'

    context.beginPath();
    context.moveTo(532, 420);
    context.lineTo(532, 350);
    context.stroke();
    context.beginPath();
    context.moveTo(566.5, 420);
    context.lineTo(566.5, 335);
    context.stroke()
    context.beginPath();
    context.moveTo(601, 420);
    context.lineTo(601, 350);
    context.stroke();

    context.beginPath();
    context.arc(566.5, 380, 45, 220 * Math.PI / 180, 320 * Math.PI / 180);
    context.stroke();

    context.lineWidth = '2'
    context.beginPath();
    context.arc(576, 393, 3.3, 0, 2 * Math.PI);
    context.stroke();
    context.beginPath();
    context.arc(557, 393, 3.3, 0, 2 * Math.PI);
    context.stroke();
}
