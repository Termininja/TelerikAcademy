module Mammal {
    export class Cat implements IWalkable {
        name: string;
        numberOfLegs: number;
        private _sound = 'miaow';

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 4;
        }

        static createCat(cat: string, age: number, weight: number): Cat {
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
        }
    }

    export class Canid {
        name: string;
        numberOfLegs: number;
        private _sound = 'wow';

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 4;
        }

        static createCanid(canid: string, age: number, weight: number): Canid {
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
        }
    }

    export class Monkey {
        name: string;
        numberOfLegs: number;

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 2;
        }

        static createMonkey(monkey: string, position: Position, age: number, weight: number): Monkey {
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
        }
    }
}