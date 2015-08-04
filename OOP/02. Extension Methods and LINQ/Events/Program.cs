/* 
 * Problem 8.* Events:
 *      Read in MSDN about the keyword event in C# and how to publish events.
 *      Re-implement the above using .NET events and following the best practices.
 */

namespace Events
{
    using System;

    public class Program
    {
        public static void Main()
        {
            while (true)
            {
                Console.CursorVisible = false;
                Console.SetCursorPosition(0, 0);
                Cow cow1 = InputCow("Betsy", 'B');
                Cow cow2 = InputCow("George", 'G');
                Cow cow3 = InputCow("Milka", 'M');
                Console.Write("[");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write('Q');
                Console.ResetColor();
                Console.WriteLine("]: Quit\n");

                Console.SetCursorPosition(10, 3);
                ConsoleKeyInfo key = Console.ReadKey();
                Console.Clear();
                Console.SetCursorPosition(0, 5);

                switch (key.Key)
                {
                    case ConsoleKey.B:
                        cow1.BeTippedOver();
                        break;
                    case ConsoleKey.G:
                        cow2.BeTippedOver();
                        break;
                    case ConsoleKey.M:
                        cow3.BeTippedOver();
                        break;
                    case ConsoleKey.Q:
                        return;
                    default:
                        Console.WriteLine(" ↑");
                        break;
                }
            }
        }

        // Input some cow in the cowshed
        private static Cow InputCow(string name, char key)
        {
            var cow = new Cow { Name = name };
            cow.Moo += Giggle;
            Console.Write("[");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(key);
            Console.ResetColor();
            Console.Write("]: Check the state of ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(name);
            Console.ResetColor();
            Console.WriteLine(" cow");

            return cow;
        }

        // What to be done in time when we have some event
        static void Giggle(object sender, CowTippedEventArgs e)
        {
            Console.Write("Giggle, giggle... we made ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write((sender as Cow).Name);
            Console.ResetColor();
            Console.WriteLine(" moo!\n");

            // Checks the state of the cow
            switch (e.CurrentCowState)
            {
                case CowState.Awake:
                    Console.Write("The cow is awake: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Run!");
                    break;
                case CowState.Sleeping:
                    Console.Write("The cow is sleeping: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Tickle it!");
                    break;
                case CowState.Dead:
                    Console.Write("The cow is dead: ");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("Butcher it!");
                    break;
                default:
                    break;
            }

            Console.ResetColor();
        }
    }
}