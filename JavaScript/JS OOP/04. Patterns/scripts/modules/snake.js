define(function () {
    'use strict';
    var Snake;
    Snake = (function () {
        function Snake() {
            this._snake = [];
        }

        Snake.prototype.body = function (element) {
            if (element != null) {
                return this._snake[element];
            }
        }

        Snake.prototype.addHead = function (element) {
            if (element != null) {
                this._snake.unshift(element);
            }
        }

        Snake.prototype.addTail = function (element) {
            if (element != null) {
                this._snake.push(element);
            }
        }

        Snake.prototype.remove = function () {
            return this._snake.pop();
        }

        Snake.prototype.length = function () {
            return this._snake.length;
        }

        return Snake;
    })();
    return Snake;
});

