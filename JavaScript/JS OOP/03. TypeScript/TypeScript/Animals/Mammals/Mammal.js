var Mammal;
(function (Mammal) {
    var Cat = (function () {
        function Cat(name) {
            this._sound = 'miaow';
            this.name = name;
            this.numberOfLegs = 4;
        }
        Cat.createCat = function (cat, age, weight) {
            switch (cat) {
                case 'jaguar':
                    return new Jaguar(name, age, weight);
                    break;
                case 'lion':
                    return new Lion(name, age, weight);
                    break;
                case 'tiger':
                    return new Tiger(name, age, weight);
                    break;
                default:
                    throw new Error('Not implemented type of cat!');
                    break;
            }
        };
        return Cat;
    })();
    Mammal.Cat = Cat;

    var Canid = (function () {
        function Canid(name) {
            this._sound = 'wow';
            this.name = name;
            this.numberOfLegs = 4;
        }
        Canid.createCanid = function (canid, age, weight) {
            switch (canid) {
                case 'dog':
                    return new Dog(name, age, weight);
                    break;
                case 'fox':
                    return new Fox(name, age, weight);
                    break;
                case 'wolf':
                    return new Wolf(name, age, weight);
                    break;
                default:
                    throw new Error('Not implemented type of canid!');
                    break;
            }
        };
        return Canid;
    })();
    Mammal.Canid = Canid;

    var Monkey = (function () {
        function Monkey(name) {
            this.name = name;
            this.numberOfLegs = 2;
        }
        Monkey.createMonkey = function (monkey, position, age, weight) {
            switch (monkey) {
                case 'chimpanzee':
                    return new Chimpanzee(name, age, weight);
                    break;
                case 'gorilla':
                    return new Gorilla(name, age, weight);
                    break;
                case 'human':
                    return new Human(name, position, age, weight);
                    break;
                default:
                    throw new Error('Not implemented type of monkey!');
                    break;
            }
        };
        return Monkey;
    })();
    Mammal.Monkey = Monkey;
})(Mammal || (Mammal = {}));
//# sourceMappingURL=Mammal.js.map
