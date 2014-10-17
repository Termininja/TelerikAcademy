namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    using Enumerations;

    public class Game
    {
        private ICollection<Guess> yourGuesses;
        private ICollection<Guess> opponentGuesses;
        private ICollection<Notification> notifications;

        public Game()
        {
            this.yourGuesses = new HashSet<Guess>();
            this.opponentGuesses = new HashSet<Guess>();
            this.notifications = new HashSet<Notification>();
        }

        [Key]
        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; }

        public GameState GameState { get; set; }

        public int YourNumber { get; set; }

        public string YourColor { get; set; }

        public string RedUserID { get; set; }
        public virtual User RedUser { get; set; }

        public string BlueUserID { get; set; }
        public virtual User BlueUser { get; set; }

        public virtual ICollection<Guess> YourGuesses
        {
            get { return this.yourGuesses; }
            set { this.yourGuesses = value; }
        }

        public virtual ICollection<Guess> OpponentGuesses
        {
            get { return this.opponentGuesses; }
            set { this.opponentGuesses = value; }
        }

        public virtual ICollection<Notification> Notifications
        {
            get { return this.notifications; }
            set { this.notifications = value; }
        }
    }
}