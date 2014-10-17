/* Create a class hierarchy by your choice with TypeScript consisting of the following:
    - At least 2 modules
    - At least 3 interfaces
    - At least 6 classes
    - At least 2 uses of inheritance
    - At least 12 methods
    - At least one generic use
    - At least one static use
    - Everything should be strongly typed
*/

module Organism {
    export class Organism {
        name: string;

        constructor(name: string) {
            this.name = name;
        }
    }

    export function CreateOrganism(organism: string, type: string, name: string, sort?: string, kind?: string, age?: number, weight?: number, position?: Position, dose?: number): Organism {
        switch (organism) {
            case 'animal':
                return Animal.CreateAnimal(type, sort, name, kind, position, age, weight);
                break;
            case 'fungus':
                return Fungus.CreateFungus(type, name, dose);
                break;
            case 'plant':
                return Plant.CreatePlant(type, name);
                break;
            case 'protist':
                return Protist.CreateProtist(type, name);
                break;
            default:
                throw new Error('Not implemented organism!');
                break;
        }
    }
}

var eagle = Organism.CreateOrganism('animal', 'bird', 'koki', 'eagle');
var shark = Organism.CreateOrganism('animal', 'fish', 'buko', 'shark');
var snake = Organism.CreateOrganism('animal', 'reptilian', 'sizi', 'snake');

var fox = Organism.CreateOrganism('animal', 'mammal', 'roxy', 'canid', 'fox', 2, 1.5);
var jaguar = Organism.CreateOrganism('animal', 'mammal', 'pusso', 'cat', 'jaguar', 7, 120);
var gorilla = Organism.CreateOrganism('animal', 'mammal', 'mona', 'monkey', 'gorilla', 4, 235);

var mushroom = Organism.CreateOrganism('fungus', 'eadable', 'agaricus');
var cherry = Organism.CreateOrganism('plant', 'tree', 'cherry');
var excavata = Organism.CreateOrganism('protist', 'excavata', 'jakobea');
