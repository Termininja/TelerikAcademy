var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Human = (function (_super) {
    __extends(Human, _super);
    function Human(name, position, age, weight) {
        _super.call(this, name);
        this._position = position;
        this._age = age;
        this._weight = weight;
    }
    Human.prototype.Speak = function (word) {
        console.log(word);
    };

    Human.prototype.Move = function (position) {
        this._position = position;
    };
    return Human;
})(Mammal.Monkey);
//# sourceMappingURL=Human.js.map
