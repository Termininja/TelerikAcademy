/*
Create a class hierarchy by your choice with TypeScript consisting of the following:
* At least 2 modules
* At least 3 interfaces
* At least 6 classes
* At least 2 uses of inheritance
* At least 12 methods
* At least one generic use
* At least one static use
* Everything should be strongly typed
*/
var __extends = this.__extends || function (d, b) {
    for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p];
    function __() { this.constructor = d; }
    __.prototype = b.prototype;
    d.prototype = new __();
};
//Basics
var currentName;
var hasPassed;
var currentCourses;
var averageMark;
var additionalInfo;
var currentState;

var EducationalState;
(function (EducationalState) {
    EducationalState[EducationalState["Online"] = 0] = "Online";
    EducationalState[EducationalState["Live"] = 1] = "Live";
    EducationalState[EducationalState["NotEnrolled"] = 2] = "NotEnrolled";
})(EducationalState || (EducationalState = {}));

function setName(name, passing, courses, mark, addInfo, state) {
    currentName = name;
    hasPassed = passing;
}

setName('Ivan', true, ['Peho', '44'], 10, true, 1 /* Live */);

console.log(currentName);


var sumeSumFunc = function (x, y) {
    return x + y;
};

var someSumFunc2;
someSumFunc2 = function (num) {
    console.log(num);
};

someSumFunc2 = function (num) {
    return console.log(num);
};

var somePerson = new Cat('Ivan', "Petrov");
var greeting = somePerson.greet();

var someDriver = new Tiger('Pesho', "Kirov", 5);

someDriver.health = 50;
console.log(someDriver.health);
console.log(Tiger.MaximumAllowedSpeed);
console.log(Tiger.getPrivateParts().legs);

var Organism;
(function (Organism) {
})(Organism || (Organism = {}));

var Animal;
(function (Animal) {
    var Fish = (function () {
        function Fish() {
        }
        return Fish;
    })();
    var Shark = (function (_super) {
        __extends(Shark, _super);
        function Shark() {
            _super.apply(this, arguments);
        }
        return Shark;
    })(Fish);
    var Dolphin = (function (_super) {
        __extends(Dolphin, _super);
        function Dolphin() {
            _super.apply(this, arguments);
        }
        return Dolphin;
    })(Fish);

    var Bird = (function () {
        function Bird() {
        }
        return Bird;
    })();
    var Eagle = (function (_super) {
        __extends(Eagle, _super);
        function Eagle() {
            _super.apply(this, arguments);
        }
        return Eagle;
    })(Bird);
    var Penguin = (function (_super) {
        __extends(Penguin, _super);
        function Penguin() {
            _super.apply(this, arguments);
        }
        return Penguin;
    })(Bird);

    var Reptilian = (function () {
        function Reptilian() {
        }
        return Reptilian;
    })();
    var Snake = (function (_super) {
        __extends(Snake, _super);
        function Snake() {
            _super.apply(this, arguments);
        }
        return Snake;
    })(Reptilian);
    var Crocodile = (function (_super) {
        __extends(Crocodile, _super);
        function Crocodile() {
            _super.apply(this, arguments);
        }
        return Crocodile;
    })(Reptilian);

    var Mammal = (function () {
        function Mammal() {
        }
        return Mammal;
    })();

    var Cat = (function (_super) {
        __extends(Cat, _super);
        //constructor
        function Cat(firstName, lastName) {
            this._id = Math.random();
            this.firstName = firstName;
            this.lastName = lastName;
        }
        //method
        Cat.prototype.greet = function () {
            return "Name: " + this.firstName + " " + this.lastName;
        };
        return Cat;
    })(Mammal);
    var Tiger = (function (_super) {
        __extends(Tiger, _super);
        //constructor
        function Tiger(firstName, lastName, experience) {
            _super.call(this, firstName, lastName);
            this.experience = experience;
            this._health = 100;

            //anonymous interface
            this.additionalInfo = {
                address: 'Sofia',
                email: 'xxx@xxx.xx'
            };
        }
        Object.defineProperty(Tiger.prototype, "health", {
            //getter
            get: function () {
                return this._health;
            },
            //setter
            set: function (newHealth) {
                if (newHealth < 0) {
                    throw new Error('Health cannot be less than zero!');
                }
                this._health = newHealth;
            },
            enumerable: true,
            configurable: true
        });


        Tiger.getPrivateParts = function () {
            return {
                legs: this._numberOfLegs,
                hands: this._numberOfHands
            };
        };

        Tiger.prototype.addVehicle = function (vehicle) {
            this.Vehicles.push(vehicle);
        };
        Tiger.prototype.removeVehicle = function (vehicle) {
            var vehicleToBeRemovedIndex = this.Vehicles.indexOf(vehicle);
            if (vehicleToBeRemovedIndex < 0) {
                throw new Error('Vehicle could not be found!');
            }

            var vehicleToBeRemoved = this.Vehicles[vehicleToBeRemovedIndex];
            vehicleToBeRemoved = this.Vehicles[this.Vehicles.length - 1];
            this.Vehicles.pop();

            return vehicleToBeRemoved;
        };
        Tiger.MaximumAllowedSpeed = 300;
        Tiger._numberOfLegs = 2;
        Tiger._numberOfHands = 2;
        return Tiger;
    })(Cat);
    var Jaguar = (function (_super) {
        __extends(Jaguar, _super);
        function Jaguar() {
            _super.apply(this, arguments);
        }
        return Jaguar;
    })(Cat);

    var Monkey = (function (_super) {
        __extends(Monkey, _super);
        function Monkey() {
            _super.apply(this, arguments);
        }
        return Monkey;
    })(Mammal);
    var Gorilla = (function (_super) {
        __extends(Gorilla, _super);
        function Gorilla() {
            _super.apply(this, arguments);
        }
        return Gorilla;
    })(Monkey);
    var Chimpanzee = (function (_super) {
        __extends(Chimpanzee, _super);
        function Chimpanzee() {
            _super.apply(this, arguments);
        }
        return Chimpanzee;
    })(Monkey);

    var Human = (function (_super) {
        __extends(Human, _super);
        function Human() {
            _super.apply(this, arguments);
        }
        return Human;
    })(Mammal);

    //exported
    var Test = (function () {
        function Test(firstName, lastName) {
            this._firstName = firstName;
            this._lastName = lastName;
        }
        return Test;
    })();
    Animal.Test = Test;
})(Animal || (Animal = {}));

var someTest = new Animal.Test("Kiro", "Stoyanov");
console.log(someTest);

//Functions
var someFunc;

someFunc = function (x, y) {
    return (x + y).toString();
};

//or the faster method by lambda
someFunc = function (x, y) {
    return (x + y).toString();
};

console.log(someFunc(3, 8));

function Sum(x, y, z, m) {
    if (typeof z === "undefined") { z = 100; }
    return x + y + z;
}

console.log(Sum(3, 8));

function Sum2(x) {
    var restNumbers = [];
    for (var _i = 0; _i < (arguments.length - 1); _i++) {
        restNumbers[_i] = arguments[_i + 1];
    }
    var sum = x;
    for (var i = 0; i < restNumbers.length; i++) {
        sum += +restNumbers[i];
    }

    return sum;
}

console.log(Sum2(1, '2', 3, '4', 5, 6, 7));

//by lambda
var otherFunc = function (firstName, secondName, age) {
    return age;
};

//Generics
var Collections;
(function (Collections) {
    var List = (function () {
        function List() {
            this._collection = [];
        }
        List.prototype.add = function (item) {
            this._collection.push(item);
        };

        Object.defineProperty(List.prototype, "count", {
            get: function () {
                return this._collection.length;
            },
            enumerable: true,
            configurable: true
        });
        return List;
    })();
    Collections.List = List;
})(Collections || (Collections = {}));

var someList = new Collections.List();
someList.add(30);
someList.add(10);

console.log(someList.count);
//# sourceMappingURL=app.js.map
