window.onload = function () {
    var canvas = document.getElementById("aircraft-canvas");
    var ctx = canvas.getContext("2d");

    function Laser(x, y, speed) {
        this.x = x;
        this.y = y;

        this.draw = function (ctx) {
            ctx.beginPath();
            ctx.moveTo(this.x, this.y);
            ctx.lineTo(this.x + 10, this.y);
            ctx.stroke();
        };

        this.move = function () {
            this.x += speed;
        };
    }

    function Fighter(x, y, speed) {
        var laserSpeed = 10;
        this.x = x;
        this.y = y;
        this.lasers = [];

        this.draw = function () {
            //body of the fighter
            ctx.beginPath();
            ctx.fillStyle = '#C96';
            ctx.moveTo(this.x + 100, (2 * this.y - 30) / 2);
            ctx.lineTo(this.x + 20, (2 * this.y - 30) / 2);
            ctx.lineTo(this.x, this.y - 30);
            ctx.lineTo(this.x, this.y);
            ctx.lineTo(this.x + 120, this.y);
            ctx.closePath();
            ctx.stroke();
            ctx.fill();

            //wing
            ctx.beginPath();
            ctx.moveTo(this.x + 35, (2 * this.y - 30) / 2 + 5);
            ctx.lineTo(this.x + 35, (2 * this.y - 30) / 2 - 45);
            ctx.lineTo(this.x + 80, (2 * this.y - 30) / 2 + 5);
            ctx.closePath();
            ctx.fill();

            //bottom cannon
            ctx.moveTo(this.x + 60, (2 * this.y - 30) / 2 - 10);
            ctx.lineTo(this.x + 80, (2 * this.y - 30) / 2 - 10);

            //middle cannon
            ctx.moveTo(this.x + 50, (2 * this.y - 30) / 2 - 20);
            ctx.lineTo(this.x + 70, (2 * this.y - 30) / 2 - 20);

            //top cannon
            ctx.moveTo(this.x + 40, (2 * this.y - 30) / 2 - 30);
            ctx.lineTo(this.x + 60, (2 * this.y - 30) / 2 - 30);

            //front cannon
            ctx.moveTo(this.x + 120, (2 * this.y + 60) / 2 - 30);
            ctx.lineTo(this.x + 130, (2 * this.y + 60) / 2 - 30);
            ctx.stroke();

            //draw the lasers
            for (var i = 0; i < this.lasers.length; i += 1) {
                this.lasers[i].draw(ctx);
            }
        };

        this.moveUp = function () {
            this.y -= speed;
        };

        this.moveDown = function () {
            this.y += speed;
        };

        this.fire = function () {
            var laserStartPoints = [{
                x: this.x + 80,
                y: this.y - 25
            }, {
                x: this.x + 70,
                y: this.y - 35
            }, {
                x: this.x + 60,
                y: this.y - 45
            }, {
                x: this.x + 120,
                y: this.y
            }];
            for (var i = 0; i < laserStartPoints.length; i += 1) {
                var laser = new Laser(laserStartPoints[i].x, laserStartPoints[i].y, laserSpeed);
                this.lasers.push(laser);
            }
        };

        this.performMove = function (maxX) {
            var i;
            for (i = 0; i < this.lasers.length; i += 1) {
                if (this.lasers[i].x >= maxX) {
                    this.lasers.splice(i, 1);
                    i--;
                }
            }
            for (i = 0; i < this.lasers.length; i += 1) {
                this.lasers[i].move();
            }
        };
    }

    function Monster(x, y) {
        this.x = x;
        this.y = y;
        var laserSpeed = 10;
        this.lasers = [];

        this.draw = function () {

            //cannons
            ctx.beginPath();
            ctx.moveTo(this.x - 12, this.y);
            ctx.lineTo(this.x - 22, this.y);
            ctx.moveTo(this.x + 10, this.y - 15);
            ctx.lineTo(this.x - 10, this.y - 15);
            ctx.moveTo(this.x + 10, this.y + 15);
            ctx.lineTo(this.x - 10, this.y + 15);
            ctx.stroke();

            //body
            ctx.beginPath();
            ctx.fillStyle = '#000';
            ctx.arc(this.x, this.y, 10, 0, 2 * Math.PI);
            ctx.stroke();
            ctx.fill();

            ctx.fillStyle = '#903';
            ctx.moveTo(this.x - 14, this.y);
            ctx.arc(this.x, this.y - 15, 5, 0, 2 * Math.PI);
            ctx.arc(this.x, this.y + 15, 5, 0, 2 * Math.PI);
            ctx.stroke();
            ctx.fill();

            ctx.beginPath();
            ctx.fillStyle = '#000';
            ctx.moveTo(this.x, this.y);
            ctx.arc(this.x, this.y - 15, 2, 0, 2 * Math.PI);
            ctx.arc(this.x, this.y + 15, 2, 0, 2 * Math.PI);
            ctx.rect(this.x - 2, this.y - 5, 5, 10);
            ctx.stroke();
            ctx.fill();

            //lasers
            for (var i = 0; i < this.lasers.length; i += 1) {
                this.lasers[i].draw(ctx);
            }
        };

        this.fire = function () {
            var laserStartPoints = [{
                x: this.x - 20,
                y: this.y - 15
            }, {
                x: this.x - 30,
                y: this.y
            }, {
                x: this.x - 20,
                y: this.y + 15
            }];
            for (var i = 0; i < laserStartPoints.length; i += 1) {
                var laser = new Laser(laserStartPoints[i].x, laserStartPoints[i].y, laserSpeed);
                this.lasers.push(laser);
            }
        };

        this.performMove = function (maxX) {
            var i;
            for (i = 0; i < this.lasers.length; i += 1) {
                if (this.lasers[i].x >= maxX) {
                    this.lasers.splice(i, 1);
                    i--;
                }
            }
            for (i = 0; i < this.lasers.length; i += 1) {
                this.lasers[i].move();
            }
        };
    }

    var fighter = new Fighter(50, 50, 15);
    var monsters = [];
    for (var i = 0; i < 10; i++) {
        var randX = Math.floor(Math.random() * 250);
        var randY = Math.floor(Math.random() * 500);
        monsters[i] = new Monster(randX + 500, randY + 50);
    }

    document.body.addEventListener("keydown", function (e) {
        if (!e) {
            e = window.event;
        }
        switch (e.keyCode) {
            case 38:
                fighter.moveUp();
                break;
            case 40:
                fighter.moveDown();
                break;
            case 32:
                fighter.fire();
                monsters[3].fire();
                break;
        }
    });

    function animation() {
        ctx.clearRect(0, 0, ctx.canvas.width, ctx.canvas.height);

        fighter.draw();
        fighter.performMove(ctx.canvas.width);

        for (var i = 0; i < monsters.length; i++) {
            monsters[i].draw();
            monsters[i].fire();
            monsters[i].performMove(ctx.canvas.width);
        }

        requestAnimationFrame(animation);
    }

    animation();
}