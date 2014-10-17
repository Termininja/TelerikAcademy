namespace BullsAndCows.WebAPI.Models.DataModels
{
    using System;

    using BullsAndCows.Models;
    using BullsAndCows.Models.Enumerations;

    public class GameDetailsDataModel
    {
        public GameDetailsDataModel(Game game)
        {
            this.ID = game.ID;
            this.Name = game.Name;
            this.DateCreated = game.DateCreated;
            this.GameState = game.GameState;
            this.Blue = game.BlueUser;
            this.Red = game.RedUser;
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public User Blue { get; set; }

        public User Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}