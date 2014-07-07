(function () {
    require(['modules/snake', 'modules/food'], function (Snake, Food) {
        var canvas = document.getElementById('canvas-container');
        var context = canvas.getContext('2d');
        var snakeX = 100;
        var snakeY = 400;
        var snakeR = 10;
        var speed = 2;
        var part = [1];
        var snakeLength = 30;
        var foodW = 10;
        var points = 0;
        var direction = 'up';
        var time = 0;

        var snake = new Snake();
        for (var i = 0; i < snakeLength; i++) {
            snake.addTail({ x: snakeX, y: snakeY + i });
        }

        function foodGenerator() {
            var foodX = Math.floor(Math.random() * (canvas.width - 4 * snakeR) + 2 * snakeR);
            var foodY = Math.floor(Math.random() * (canvas.height - 4 * snakeR) + 2 * snakeR);
            var food = new Food(foodX, foodY);

            return food;
        }

        var food = foodGenerator();
        game();

        function game() {
            context.fillStyle = '#00FF66';
            context.clearRect(0, 0, canvas.width, canvas.height);
            for (var i = 0; i < snake.length() ; i++) {
                context.beginPath();
                context.arc(snake.body(i).x, snake.body(i).y, snakeR, 0, 2 * Math.PI);
                context.fill();
            }

            //Draw food
            context.beginPath();
            context.fillStyle = 'yellow';
            context.rect(food.x, food.y, foodW, foodW);
            context.fill();

            //Draw statistics
            context.beginPath();
            context.fillStyle = 'white';
            context.font = '20px Consolas';
            context.fillText('Points: ' + points, canvas.width - 150, 30);
            context.fillText('frames: ' + time, 20, 30);
            context.fillText('speed: ' + speed.toFixed(1), 20, 55);
            context.fillText('length: ' + snake.length() / 10, 20, 80);

            switch (direction) {
                case 'up': snake.addHead({ x: snake.body(0).x, y: snake.body(0).y - speed }); break;
                case 'down': snake.addHead({ x: snake.body(0).x, y: snake.body(0).y + speed }); break;
                case 'right': snake.addHead({ x: snake.body(0).x + speed, y: snake.body(0).y }); break;
                case 'left': snake.addHead({ x: snake.body(0).x - speed, y: snake.body(0).y }); break;
                default: break;
            }
            snake.remove();

            //Snake & Food interaction
            if ((food.x <= snake.body(0).x && snake.body(0).x <= food.x + foodW &&
                food.y <= snake.body(0).y - snakeR && snake.body(0).y - snakeR <= food.y + foodW) ||
                (food.x <= snake.body(0).x && snake.body(0).x <= food.x + foodW &&
                food.y <= snake.body(0).y + snakeR && snake.body(0).y + snakeR <= food.y + foodW) ||
                (food.x <= snake.body(0).x - snakeR && snake.body(0).x - snakeR <= food.x + foodW &&
                food.y <= snake.body(0).y && snake.body(0).y <= food.y + foodW) ||
                (food.x <= snake.body(0).x + snakeR && snake.body(0).x + snakeR <= food.x + foodW &&
                food.y <= snake.body(0).y && snake.body(0).y <= food.y + foodW)) {

                food = foodGenerator();
                points += 10;
                speed += 0.1;
                for (var i = 0; i < 10; i++) {
                    snake.addTail({ x: snake.body(snake.length() - 1).x, y: snake.body(snake.length() - 1).y });
                }
            }

            //Snake head & snake tail interaction
            for (var i = 10; i < snake.length() ; i++) {
                if (snake.body(0).x >= snake.body(i).x - snakeR + 1 && snake.body(0).x <= snake.body(i).x + snakeR - 1 &&
                    snake.body(0).y >= snake.body(i).y - snakeR + 1 && snake.body(0).y <= snake.body(i).y + snakeR - 1) {
                    gameOver();
                    return;
                }
            }

            //Snake & border interaction
            if (snake.body(0).y - snakeR < 0 || snake.body(0).y + snakeR > canvas.height ||
                snake.body(0).x - snakeR < 0 || snake.body(0).x + snakeR > canvas.width) {
                gameOver();
                return;
            }

            time++;
            requestAnimationFrame(game);
        }

        //GameOver screen
        function gameOver() {
            context.beginPath();
            context.fillStyle = 'rgba(255,0,0,0.4)';
            context.rect(0, 0, canvas.width, canvas.height);
            context.fill();
            context.fillStyle = 'white';
            context.font = '60px Times New Roman';
            context.fillText('Game Over', 250, 200);
        }

        //Keyboard input detection
        window.onkeyup = function (e) {
            switch (e.keyCode) {
                case 37: direction = 'left'; break;
                case 38: direction = 'up'; break;
                case 39: direction = 'right'; break;
                case 40: direction = 'down'; break;
                default: break;
            }
        }
    });
}).call(this);