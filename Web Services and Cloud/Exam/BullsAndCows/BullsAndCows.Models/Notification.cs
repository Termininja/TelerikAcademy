namespace BullsAndCows.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using Enumerations;

    public class Notification
    {
        [Key]
        public int ID { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        [Required]
        public NotificationType NotificationType { get; set; }

        [Required]
        public NotificationState NotificationState { get; set; }

        public int GameID { get; set; }

        public virtual Game Game { get; set; }
    }
}