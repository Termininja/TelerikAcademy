namespace Animals
{
    public class Dog : Animal
    {
        private const string MusicPathMale = @"..\..\..\Animals\Sounds\dog-m.wav";
        private const string MusicPathFemale = @"..\..\..\Animals\Sounds\dog-f.wav";

        public Dog(string name, byte age, Sex sex)
            : base(name, age, sex, sex == Sex.Male ? MusicPathMale : MusicPathFemale) { }
    }
}