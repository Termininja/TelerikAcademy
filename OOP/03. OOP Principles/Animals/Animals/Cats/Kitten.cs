namespace Animals
{
    public class Kitten : Cat
    {
        private const string MusicPath = @"..\..\..\Animals\Sounds\kitten.wav";

        public Kitten(string name, byte age)
            : base(name, age, Sex.Female, MusicPath) { }
    }
}