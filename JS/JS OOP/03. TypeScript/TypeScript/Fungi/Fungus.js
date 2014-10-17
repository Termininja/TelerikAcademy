var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Fungus;
(function (Fungus) {
    var Fungi = (function () {
        function Fungi(name) {
            this.name = name;
        }
        return Fungi;
    })();
    Fungus.Fungi = Fungi;

    var PoisonousFungi = (function (_super) {
        __extends(PoisonousFungi, _super);
        function PoisonousFungi(name, dose) {
            _super.call(this, name);
            this.dose = dose;
        }
        return PoisonousFungi;
    })(Fungi);
    Fungus.PoisonousFungi = PoisonousFungi;

    var EadableFungi = (function (_super) {
        __extends(EadableFungi, _super);
        function EadableFungi(name) {
            _super.call(this, name);
        }
        return EadableFungi;
    })(Fungi);
    Fungus.EadableFungi = EadableFungi;

    function CreateFungus(type, name, dose) {
        var fungus;

        switch (type) {
            case 'poisonous':
                fungus = new PoisonousFungi(name, dose);
                break;
            case 'eadable':
                fungus = new EadableFungi(name);
                break;
            default:
                throw new Error('Not implemented type of fungus!');
                break;
        }

        console.info('A new fungus ' + '(type: ' + type + ', name: ' + name + ') was created.');

        return fungus;
    }
    Fungus.CreateFungus = CreateFungus;
})(Fungus || (Fungus = {}));
//# sourceMappingURL=Fungus.js.map
