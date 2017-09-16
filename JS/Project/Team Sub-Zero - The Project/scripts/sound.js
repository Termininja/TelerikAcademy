var backgroundMusic = loadSound('audio/intro.mp3');
var levelMusic = loadSound('audio/level.mp3');
var bombSound = loadSound('audio/bomb.mp3');
var hitSound = loadSound('audio/hit.mp3');
var missSound = loadSound('audio/miss.mp3');

$('#music').on('click', function () {
    if (levelMusic.paused) {
        levelMusic.play();
        $(this).attr('src', 'images/icons/sound-on.png');
    }
    else {
        //levelMusic.volume = 0.2;
        levelMusic.pause();
        $(this).attr('src', 'images/icons/sound-off.png');
    }
});

function loadSound(url) {
    var audio = new Audio(url);
    audio.load();
    return audio;
}