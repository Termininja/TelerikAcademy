class Human<T> extends Mammal.Monkey {
    private _position: Position;
    private _age: number;
    private _weight: number;

    constructor(name: string, position: Position, age: number, weight: number) {
        super(name);
        this._position = position;
        this._age = age;
        this._weight = weight;
    }

    Speak(word: T): void {
        console.log(word);
    }

    Move(position): void {
        this._position = position;
    }
}