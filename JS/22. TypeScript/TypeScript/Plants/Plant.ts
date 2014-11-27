module Plant {
    export class Plant {
        name: string;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Tree extends Plant {
        constructor(name: string) {
            super(name);
        }
    }

    export class Bush extends Plant {
        constructor(name: string) {
            super(name);
        }
    }

    export class Grass extends Plant {
        constructor(name: string) {
            super(name);
        }
    }

    export function CreatePlant(type: string, name: string): Plant {
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

        console.info(
            'A new plant ' + '(type: ' + type +
            ', name: ' + name + ') was created.')

        return plant;
    }
}