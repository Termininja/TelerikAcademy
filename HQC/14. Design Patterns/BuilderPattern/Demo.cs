/*
 * Builder Pattern is rarely used, only useful if complex objects consisting
 * of multiple parts need to be constructed.
 * 
 * The director (ComputerShop) implements a method that is responsible for
 * the sequence of steps of an object creation process. It takes an abstract
 * builder class as input parameter and delegates the real creation to it.
 * 
 * The abstract builder class defines the interface that all inheriting
 * concrete builders will use for object creation.
 * 
 * The final object contains all different parts that get assembled by the
 * concrete builder classes. Those may differ from each other depending on
 * the implementations.
 * 
 */

using System;

namespace BuilderPattern
{
    class Demo
    {
        static void Main()
        {
            Builder();
        }

        private static void Builder()
        {
            ComputerShop computerShop = new ComputerShop();
            ComputerBuilder computerBuilder;

            computerBuilder = new LaptopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new DesktopBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();

            computerBuilder = new AppleBuilder();
            computerShop.ConstructComputer(computerBuilder);
            computerBuilder.Computer.DisplayConfiguration();
            Console.ReadKey();
        }
    }
}