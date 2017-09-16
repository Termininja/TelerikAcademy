var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Wolf = (function (_super) {
    __extends(Wolf, _super);
    function Wolf(name, age, weight) {
        _super.call(this, name);
        this._age = age;
        this._weight = weight;
    }
    return Wolf;
})(Mammal.Canid);
//# sourceMappingURL=Wolf.js.map
