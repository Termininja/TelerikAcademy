module Protist {
    export class Protist {
        name: string;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class Chromista extends Protist {
        constructor(name: string) {
            super(name);
        }
    }

    export class Excavata extends Protist {
        constructor(name: string) {
            super(name);
        }
    }

    export class Rhizaria extends Protist {
        constructor(name: string) {
            super(name);
        }
    }

    export function CreateProtist(type: string, name: string): Protist {
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

        console.info(
            'A new protist ' + '(type: ' + type +
            ', name: ' + name + ') was created.')

        return protist;
    }
}