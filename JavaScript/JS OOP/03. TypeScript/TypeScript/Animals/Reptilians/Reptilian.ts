module Reptilian {
    export class Snake implements IWalkable {
        name: string;
        numberOfLegs: number;

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 0;
        }
    }

    export class Crocodile implements IWalkable {
        name: string;
        numberOfLegs: number;

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 4;
        }
    }

    export class Tortoise implements IWalkable {
        name: string;
        numberOfLegs: number;

        constructor(name: string) {
            this.name = name;
            this.numberOfLegs = 4;
        }
    }
}
