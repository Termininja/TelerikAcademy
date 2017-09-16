module Fungus {
    export class Fungi {
        name: string;

        constructor(name: string) {
            this.name = name;
        }
    }

    export class PoisonousFungi extends Fungi implements IPoisonous {
        dose: number;

        constructor(name: string, dose: number) {
            super(name);
            this.dose = dose;
        }
    }

    export class EadableFungi extends Fungi implements IEadable {
        constructor(name: string) {
            super(name);
        }
    }

    export function CreateFungus(type: string, name: string, dose?: number): Fungi {
        var fungus;

        switch (type) {
            case 'poisonous':
                fungus = new PoisonousFungi(name, dose);
                break;
            case 'eadable':
                fungus = new EadableFungi(name);
                break;
            default:
                throw new Error('Not implemented type of fungus!');
                break;
        }

        console.info(
            'A new fungus ' + '(type: ' + type +
            ', name: ' + name + ') was created.')

        return fungus;
    }
}
