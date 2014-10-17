var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Protist;
(function (_Protist) {
    var Protist = (function () {
        function Protist(name) {
            this.name = name;
        }
        return Protist;
    })();
    _Protist.Protist = Protist;

    var Chromista = (function (_super) {
        __extends(Chromista, _super);
        function Chromista(name) {
            _super.call(this, name);
        }
        return Chromista;
    })(Protist);
    _Protist.Chromista = Chromista;

    var Excavata = (function (_super) {
        __extends(Excavata, _super);
        function Excavata(name) {
            _super.call(this, name);
        }
        return Excavata;
    })(Protist);
    _Protist.Excavata = Excavata;

    var Rhizaria = (function (_super) {
        __extends(Rhizaria, _super);
        function Rhizaria(name) {
            _super.call(this, name);
        }
        return Rhizaria;
    })(Protist);
    _Protist.Rhizaria = Rhizaria;

    function CreateProtist(type, name) {
        var protist;

        switch (type) {
            case 'chromista':
                protist = new Chromista(name);
                break;
            case 'excavata':
                protist = new Excavata(name);
                break;
            case 'rhizaria':
                protist = new Rhizaria(name);
                break;
            default:
                throw new Error('Not implemented type of protist!');
                break;
        }

        console.info('A new protist ' + '(type: ' + type + ', name: ' + name + ') was created.');

        return protist;
    }
    _Protist.CreateProtist = CreateProtist;
})(Protist || (Protist = {}));
//# sourceMappingURL=Protist.js.map
