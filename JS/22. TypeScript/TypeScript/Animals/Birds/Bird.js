var Bird;
(function (Bird) {
    var Eagle = (function () {
        function Eagle(name) {
            this.name = name;
        }
        return Eagle;
    })();
    Bird.Eagle = Eagle;

    var Penguin = (function () {
        function Penguin(name) {
            this.name = name;
        }
        return Penguin;
    })();
    Bird.Penguin = Penguin;

    var Stork = (function () {
        function Stork(name) {
            this.name = name;
        }
        return Stork;
    })();
    Bird.Stork = Stork;
})(Bird || (Bird = {}));
//# sourceMappingURL=Bird.js.map
