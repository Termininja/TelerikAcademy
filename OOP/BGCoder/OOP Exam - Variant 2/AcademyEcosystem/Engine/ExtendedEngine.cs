namespace AcademyEcosystem
{
    public class ExtendedEngine : Engine
    {
        protected override void ExecuteBirthCommand(string[] command)
        {
            switch (command[1])
            {
                case "wolf":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        this.AddOrganism(new Wolf(name, position));
                        break;
                    }
                case "lion":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        this.AddOrganism(new Lion(name, position));
                        break;
                    }
                case "grass":
                    {
                        Point position = Point.Parse(command[2]);
                        this.AddOrganism(new Grass(position));
                        break;
                    }
                case "boar":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        this.AddOrganism(new Boar(name, position));
                        break;
                    }
                case "zombie":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        this.AddOrganism(new Zombie(name, position));
                        break;
                    }
                default:
                    base.ExecuteBirthCommand(command);
                    break;
            }
        }
    }
}
