namespace Animals
{
    public class Frog : Animal
    {
        private const string MusicPathMale = @"..\..\..\Animals\Sounds\frog-m.wav";
        private const string MusicPathFemale = @"..\..\..\Animals\Sounds\frog-f.wav";

        public Frog(string name, byte age, Sex sex)
            : base(name, age, sex, sex == Sex.Male ? MusicPathMale : MusicPathFemale) { }
    }
}