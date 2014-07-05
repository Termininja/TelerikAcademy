class Wolf extends Mammal.Canid {
    private _age;
    private _weight;

    constructor(name: string, age: number, weight: number) {
        super(name);
        this._age = age;
        this._weight = weight;
    }
}
