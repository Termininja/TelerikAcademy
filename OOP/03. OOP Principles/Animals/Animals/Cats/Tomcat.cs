namespace Animals
{
    public class Tomcat : Cat
    {
        private const string MusicPath = @"..\..\..\Animals\Sounds\tomcat.wav";

        public Tomcat(string name, byte age)
            : base(name, age, Sex.Male, MusicPath) { }
    }
}