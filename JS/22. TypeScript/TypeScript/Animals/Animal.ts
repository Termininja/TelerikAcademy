module Animal {
    export function CreateAnimal(type: string, sort: string, name: string, kind?: string, position?: Position, age?: number, weight?: number): IAnimal {
        var animal;

        switch (type) {
            case 'mammal':
                switch (sort) {
                    case 'canid':
                        animal = Mammal.Canid.createCanid(kind, age, weight);
                        break;
                    case 'cat':
                        animal = Mammal.Cat.createCat(kind, age, weight);
                        break;
                    case 'monkey':
                        animal = Mammal.Monkey.createMonkey(kind, position, age, weight);
                        break;
                    default:
                        throw new Error('Not implemented sort of mammal!');
                        break;
                }
                break;
            case 'fish':
                switch (sort) {
                    case 'shark':
                        animal = new Fish.Shark(name);
                        break;
                    case 'dolphin':
                        animal = new Fish.Dolphin(name);
                        break;
                    case 'whale':
                        animal = new Fish.Whale(name);
                        break;
                    default:
                        throw new Error('Not implemented sort of fish!');
                        break;
                }
                break;
            case 'bird':
                switch (sort) {
                    case 'eagle':
                        animal = new Bird.Eagle(name);
                        break;
                    case 'penguin':
                        animal = new Bird.Penguin(name);
                        break;
                    case 'stork':
                        animal = new Bird.Stork(name);
                        break;
                    default:
                        throw new Error('Not implemented sort of bird!');
                        break;
                }
                break;
            case 'reptilian':
                switch (sort) {
                    case 'crocodile':
                        animal = new Reptilian.Crocodile(name);
                        break;
                    case 'snake':
                        animal = new Reptilian.Snake(name);
                        break;
                    case 'tortoise':
                        animal = new Reptilian.Tortoise(name);
                        break;
                    default:
                        throw new Error('Not implemented sort of reptilian!');
                        break;
                }
                break;
            default:
                throw new Error('Not implemented type of animal!');
                break;
        }

        console.info(
            'A new ' + ((kind) ? sort + ' ' : '') + 'animal ' +
            animal.constructor.name + ' (type: ' + type +
            ', name: ' + name + ') was created.')

        return animal;
    }
}
