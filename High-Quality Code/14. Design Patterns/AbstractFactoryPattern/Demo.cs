/*
 * Abstract Factory Pattern creates instances of classes belonging to different families.
 * Its very frequently used and very useful.
 * 
 * The abstract factory class defines the abstract methods that have to be implemented by
 * concrete factory classes. It serves as interface and contract definition.
 * 
 * The concrete factory classes contain the real implementation that define which classes
 * are created during run-time.
 *
 * The methods return values are also defined by abstract classes, this allows a high
 * flexibility and independence, leading to methods that must only be implemented once.
 * 
 * The returned classes are however specific to each concrete factory class.
 * 
 */

namespace AbstractFactoryPattern
{
    using System;

    class Demo
    {
        static void Main()
        {
            AbstractFactory();
        }

        public static void AbstractFactory()
        {
            CarFactory audiFactory = new AudiFactory();
            Driver driver1 = new Driver(audiFactory);
            driver1.CompareSpeed(); ;

            CarFactory mercedesFactory = new MercedesFactory();
            Driver driver2 = new Driver(mercedesFactory);
            driver2.CompareSpeed();
        }
    }
}