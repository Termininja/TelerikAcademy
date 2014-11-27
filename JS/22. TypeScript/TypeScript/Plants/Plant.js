var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
var Plant;
(function (_Plant) {
    var Plant = (function () {
        function Plant(name) {
            this.name = name;
        }
        return Plant;
    })();
    _Plant.Plant = Plant;

    var Tree = (function (_super) {
        __extends(Tree, _super);
        function Tree(name) {
            _super.call(this, name);
        }
        return Tree;
    })(Plant);
    _Plant.Tree = Tree;

    var Bush = (function (_super) {
        __extends(Bush, _super);
        function Bush(name) {
            _super.call(this, name);
        }
        return Bush;
    })(Plant);
    _Plant.Bush = Bush;

    var Grass = (function (_super) {
        __extends(Grass, _super);
        function Grass(name) {
            _super.call(this, name);
        }
        return Grass;
    })(Plant);
    _Plant.Grass = Grass;

    function CreatePlant(type, name) {
        var plant;

        switch (type) {
            case 'tree':
                plant = new Tree(name);
                break;
            case 'bush':
                plant = new Bush(name);
                break;
            case 'grass':
                plant = new Grass(name);
                break;
            default:
                throw new Error('Not implemented type of plant!');
                break;
        }

        console.info('A new plant ' + '(type: ' + type + ', name: ' + name + ') was created.');

        return plant;
    }
    _Plant.CreatePlant = CreatePlant;
})(Plant || (Plant = {}));
//# sourceMappingURL=Plant.js.map
