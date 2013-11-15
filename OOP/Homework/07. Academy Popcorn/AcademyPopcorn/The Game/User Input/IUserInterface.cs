using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AcademyPopcorn
{
    // Check for user input
    public interface IUserInterface
    {
        // If the user input is for left direction
        event EventHandler OnLeftPressed;

        // If the user input is for right direction
        event EventHandler OnRightPressed;

        // If the user input is for action
        event EventHandler OnActionPressed;

        // Checking what happend
        void ProcessInput();
    }
}
