namespace BullsAndCows.WebAPI.Models.DataModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GuessDataModel
    {
        public static Expression<Func<Guess, GuessDataModel>> FromComment
        {
            get
            {
                return g => new GuessDataModel
                {
                    ID = g.ID,
                    Username = g.Username,
                    BullsCount = g.BullsCount,
                    CowsCount = g.CowsCount,
                    DateMade = g.DateMade,
                    Number = g.Number
                };
            }
        }

        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}
