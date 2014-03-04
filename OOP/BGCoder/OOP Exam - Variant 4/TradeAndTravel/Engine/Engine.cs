using System;

namespace TradeAndTravel
{
    public class Engine
    {
        // Field
        protected InteractionManager interactionManager;

        // Constructor
        public Engine(InteractionManager interactionManager)
        {
            this.interactionManager = interactionManager;
        }

        // Methods
        public void ParseAndDispatch(string command)
        {
            this.interactionManager.HandleInteraction(command.Split(' '));
        }

        public void Start()
        {
            bool endCommandReached = false;
            while (!endCommandReached)
            {
                string command = Console.ReadLine();
                if (command != "end") this.ParseAndDispatch(command);
                else endCommandReached = true;
            }
        }
    }
}
