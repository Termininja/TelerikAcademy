using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    public class KeyboardInterface : IUserInterface
    {
        public void ProcessInput()
        {
            if (Console.KeyAvailable)
            {
                var keyInfo = Console.ReadKey();
                while (Console.KeyAvailable)
                {
                    Console.ReadKey();
                    ClearInputKey();
                }
                switch (keyInfo.Key)
                {
                    // If left arrow key-button is pressed
                    case ConsoleKey.A:
                        if (this.OnLeftPressed != null) this.OnLeftPressed(this, new EventArgs());
                        break;

                    // If right arrow key-button is pressed
                    case ConsoleKey.D:
                        if (this.OnRightPressed != null) this.OnRightPressed(this, new EventArgs());
                        break;

                    // If spacebar key-button is pressed
                    case ConsoleKey.Spacebar:
                        if (this.OnActionPressed != null) this.OnActionPressed(this, new EventArgs());
                        break;

                    default: break;
                }
                ClearInputKey();
            }
        }

        private static void ClearInputKey()
        {
            Console.Write("\b \b");
        }

        public event EventHandler OnLeftPressed;

        public event EventHandler OnRightPressed;

        public event EventHandler OnActionPressed;
    }
}
