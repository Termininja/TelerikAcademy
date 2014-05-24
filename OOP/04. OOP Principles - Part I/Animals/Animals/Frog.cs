using System;
using System.IO;
using System.Media;

namespace Animals
{
    class Frog : Animal, ISound
    {
        // Constructor
        public Frog(string name, byte age, Sex sex) : base(name, age, sex) { }

        // Produce sound
        public void Sound(Sex sex)
        {
            MemoryStream sound = new MemoryStream();
            if (sex == Sex.Male) sound = new MemoryStream(File.ReadAllBytes(@"..\..\..\Animals\Sounds\frog-m.wav"));
            if (sex == Sex.Female) sound = new MemoryStream(File.ReadAllBytes(@"..\..\..\Animals\Sounds\frog-f.wav"));
            using (sound)
            {
                SoundPlayer play = new SoundPlayer(sound);
                play.Play();
            }
        }
    }
}