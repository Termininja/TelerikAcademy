var Reptilian;
(function (Reptilian) {
    var Snake = (function () {
        function Snake(name) {
            this.name = name;
            this.numberOfLegs = 0;
        }
        return Snake;
    })();
    Reptilian.Snake = Snake;

    var Crocodile = (function () {
        function Crocodile(name) {
            this.name = name;
            this.numberOfLegs = 4;
        }
        return Crocodile;
    })();
    Reptilian.Crocodile = Crocodile;

    var Tortoise = (function () {
        function Tortoise(name) {
            this.name = name;
            this.numberOfLegs = 4;
        }
        return Tortoise;
    })();
    Reptilian.Tortoise = Tortoise;
})(Reptilian || (Reptilian = {}));
//# sourceMappingURL=Reptilian.js.map
