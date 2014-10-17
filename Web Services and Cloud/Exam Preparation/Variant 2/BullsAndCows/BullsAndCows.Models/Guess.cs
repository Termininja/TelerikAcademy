namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Guess
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }

        public string UserID { get; set; }

        public virtual User User { get; set; }

        public int GameID { get; set; }

        public virtual Game Game { get; set; }
    }
}