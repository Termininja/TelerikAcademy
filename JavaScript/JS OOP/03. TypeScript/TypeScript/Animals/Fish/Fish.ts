module Fish {
    export class Shark implements ISwimmable {
        name: string;
        speed: number;
        depth: number;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Dolphin implements ISwimmable {
        name: string;
        speed: number;
        depth: number;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Whale implements ISwimmable {
        name: string;
        speed: number;
        depth: number;

        constructor(name: string) {
            this.name = name;
        }
    }
}