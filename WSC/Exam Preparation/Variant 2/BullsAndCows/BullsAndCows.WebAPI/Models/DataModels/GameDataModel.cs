namespace BullsAndCows.WebAPI.Models.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;
    using BullsAndCows.Models.Enumerations;

    public class GameDataModel
    {
        public GameDataModel()
        {
        }

        public static Expression<Func<Game, GameDataModel>> FromGame
        {
            get
            {
                return g => new GameDataModel
                {
                    ID = g.ID,
                    Name = g.Name,
                    Blue = g.BlueUser,
                    Red = g.RedUser,
                    GameState = g.GameState,
                    DateCreated = g.DateCreated
                };
            }
        }

        public int ID { get; set; }

        public string Name { get; set; }

        public User Blue { get; set; }

        public User Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }
    }
}