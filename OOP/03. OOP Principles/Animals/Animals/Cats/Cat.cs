namespace Animals
{
    public abstract class Cat : Animal
    {
        public Cat(string name, byte age, Sex sex, string musicPath)
            : base(name, age, sex, musicPath) { }
    }
}