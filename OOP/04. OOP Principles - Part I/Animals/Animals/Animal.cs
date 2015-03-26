namespace Animals
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Media;

    public abstract class Animal : ISound
    {
        protected string musicPath;

        public Animal(string name, byte age, Sex sex, string musicPath)
        {
            this.Name = name;
            this.Age = age;
            this.Sex = sex;
            this.musicPath = musicPath;
        }

        public string Name { get; set; }

        public byte Age { get; set; }

        public Sex Sex { get; set; }

        public static double? AverageAge<T>(List<T> animals) where T : Animal
        {
            return animals.Average(animal => animal.Age);
        }

        public void Sound()
        {
            using (var sound = new MemoryStream(File.ReadAllBytes(this.musicPath)))
            {
                new SoundPlayer(sound).Play();
            }
        }
    }
}