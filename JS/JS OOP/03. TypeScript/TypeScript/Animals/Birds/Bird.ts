module Bird {
    export class Eagle implements IFlyable {
        name: string;
        flight: number;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Penguin implements IFlyable {
        name: string;
        flight: number;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Stork implements IFlyable {
        name: string;
        flight: number;

        constructor(name: string) {
            this.name = name;
        }
    }
}