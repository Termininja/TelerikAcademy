var Fish;
(function (Fish) {
    var Shark = (function () {
        function Shark(name) {
            this.name = name;
        }
        return Shark;
    })();
    Fish.Shark = Shark;

    var Dolphin = (function () {
        function Dolphin(name) {
            this.name = name;
        }
        return Dolphin;
    })();
    Fish.Dolphin = Dolphin;

    var Whale = (function () {
        function Whale(name) {
            this.name = name;
        }
        return Whale;
    })();
    Fish.Whale = Whale;
})(Fish || (Fish = {}));
//# sourceMappingURL=Fish.js.map
