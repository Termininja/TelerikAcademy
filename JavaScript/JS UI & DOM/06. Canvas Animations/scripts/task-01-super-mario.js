var canvas = document.getElementById('canvas');
var ctx = canvas.getContext('2d');
var backgroundMusic = loadSound('sounds/theme.mp3');
var jumpSound = loadSound("sounds/jump.mp3");
var crouchSound = loadSound("sounds/crouch.mp3");
var lastKeyPressed = 0;
var step = 20;

var mario = { x: 350, y: 320, image: 'images/mario.png' };

var img = new Image();
img.src = mario.image;

window.onload = function () {
    draw();
    backgroundMusic.play();
    action();
};

function action() {
    document.onkeydown = function (e) {
        ctx.clearRect(0, 0, 800, 500);
        if (e.keyCode == 38) jump();
        else if (e.keyCode == 37 && mario.x > 0) left();
        else if (e.keyCode == 39 && mario.x < 670) right();
        else if (e.keyCode == 40) crouch();

        img.src = mario.image;
        setInterval(function () { draw() }, 3);
    }

    document.onkeyup = function myfunction() {
        ctx.clearRect(0, 0, 800, 500);
        mario.image = 'images/mario.png';
        img.src = mario.image;
        setInterval(function () { draw() }, 3);
    }

    function jump() {
        mario.image = 'images/mario.png';
        var call = setInterval(function () {
            ctx.clearRect(0, 0, 800, 500);
            mario.y -= step;
            draw();
            if (mario.y < 150) {
                step = -20;
            }
            if (mario.y >= 320) {
                clearInterval(call);
                step = 20;
            }
        }, 30);
        jumpSound.play();
    }

    function left() {
        if (lastKeyPressed == 37) {
            mario.image = 'images/left2.png';
            lastKeyPressed = 0;
        }
        else if (lastKeyPressed == 0 || lastKeyPressed == 39 || lastKeyPressed == 38 || lastKeyPressed == 40) {
            mario.image = 'images/left1.png';
            lastKeyPressed = 37;
        }
        mario.x -= step;
    }

    function right() {
        if (lastKeyPressed == 39) {
            mario.image = 'images/right2.png';
            lastKeyPressed = 0;
        }
        else if (lastKeyPressed == 0 || lastKeyPressed == 37 || lastKeyPressed == 38 || lastKeyPressed == 40) {
            mario.image = 'images/right1.png';
            lastKeyPressed = 39;
        }
        mario.x += step;
    }

    function crouch() {
        mario.image = 'images/crouch.png';
        lastKeyPressed = 40;
    }
}

function draw() {
    ctx.drawImage(img, mario.x, mario.y);
}

function loadSound(url) {
    var audio = new Audio();
    audio.preload = "auto";
    audio.src = url;
    audio.load();
    return audio;
}