using System;
using System.IO;
using System.Media;

namespace Animals
{
    class Dog : Animal, ISound
    {
        // Constructor
        public Dog(string name, byte age, Sex sex) : base(name, age, sex) { }

        // Produce sound
        public void Sound(Sex sex)
        {
            MemoryStream sound = new MemoryStream();
            if (sex == Sex.Male) sound = new MemoryStream(File.ReadAllBytes(@"..\..\..\Animals\Sounds\dog-m.wav"));
            if (sex == Sex.Female) sound = new MemoryStream(File.ReadAllBytes(@"..\..\..\Animals\Sounds\dog-f.wav"));
            using (sound)
            {
                SoundPlayer play = new SoundPlayer(sound);
                play.Play();
            }
        }
    }
}