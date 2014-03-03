using System;
using System.Collections.Generic;

namespace AcademyRPG
{
    class ExtendedEngine : Engine
    {
        public override void ExecuteCreateObjectCommand(string[] command)
        {
            switch (command[1])
            {
                case "knight":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        int owner = int.Parse(command[4]);
                        this.AddObject(new Knight(name, position, owner));
                        break;
                    }
                case "house":
                    {
                        Point position = Point.Parse(command[2]);
                        int owner = int.Parse(command[3]);
                        this.AddObject(new House(position, owner));
                        break;
                    }
                case "giant":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        this.AddObject(new Giant(name, position));
                        break;
                    }
                case "rock":
                    {
                        int hitPoints = int.Parse(command[2]);
                        Point position = Point.Parse(command[3]);
                        this.AddObject(new Rock(hitPoints, position));
                        break;
                    }
                case "ninja":
                    {
                        string name = command[2];
                        Point position = Point.Parse(command[3]);
                        int owner = int.Parse(command[4]);
                        this.AddObject(new Ninja(name, position, owner));
                        break;
                    }
                default:
                    base.ExecuteCreateObjectCommand(command);
                    break;
            }
        }
    }
}