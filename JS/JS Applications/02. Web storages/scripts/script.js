var secretNumber = generateRandomNumber();
var highScores;
var attempts = 0;

if (!Storage.prototype.setObject) {
    Storage.prototype.setObject = function setObject(key, obj) {
        this.setItem(key, JSON.stringify(obj));
    };
}
if (!Storage.prototype.getObject) {
    Storage.prototype.getObject = function getObject(key) {
        return JSON.parse(this.getItem(key));
    };
}

// Generates a random number 'abcd' with 4 different digits like object
function generateRandomNumber() {
    function digitGen(from, count) {
        return Math.floor(Math.random() * count + from);
    }

    return [digitGen(1, 9), digitGen(0, 10), digitGen(0, 10), digitGen(0, 10)];
};

// At each turn the player enters a four-digit number
function readNumber() {
    var sheep = 0;
    var rams = 0;
    var isGuessed = [false, false, false, false];
    var guessNumber = document.getElementById('number').value.split('');

    for (var i = 0; i < 4; i++) {
        if (secretNumber[i] == guessNumber[i]) {
            isGuessed[i] = 'ram';
            rams++;
            continue;
        }
        for (var j = 0; j < 4; j++) {
            if (i != j && isGuessed[i] === false && guessNumber[i] == secretNumber[j]) {
                isGuessed[j] = 'sheep';
                sheep++;
            }
        }
    }

    attempts++;
    document.getElementById('rams').innerHTML = rams;
    document.getElementById('sheep').innerHTML = sheep;

    if (rams === 4) {
        document.getElementById('hidden').style.display = 'inline-block';
    }
};

// Ask the player for a nickname
function readName() {
    var name = document.getElementById('name').value;

    // Save the nickname inside the localStorage
    if (localStorage.getObject('highScores') === null) {
        highScores = {};
    }
    else {
        highScores = localStorage.getObject('highScores');
    }
    highScores[name] = attempts;
    localStorage.setObject('highScores', highScores);
    showHighScores();
}

// Display the high-score list
function showHighScores() {
    var scores = document.getElementById('highScores');
    scores.style.display = 'inline-block';

    var sortedPlayers = [];
    for (var s in highScores) {
        sortedPlayers.push([s, highScores[s]]);
        sortedPlayers.sort(function (a, b) { return a[1] - b[1] });
    }

    var result = '';
    for (var i in sortedPlayers) {
        result += sortedPlayers[i] + '<br/>'
    }

    scores.innerHTML = result;
    scores.innerHTML += '<br/>Restart the browser and try again.'
}