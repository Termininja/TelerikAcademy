namespace BullsAndCows.WebAPI.Models.DataModels
{
    using System;
    using System.Linq.Expressions;

    using BullsAndCows.Models;
    using BullsAndCows.Models.Enumerations;

    public class NotificationDataModel
    {
        public NotificationDataModel()
        {
        }

        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return n => new NotificationDataModel
                {
                    ID = n.ID,
                    Message = n.Message,
                    NotificationState = n.NotificationState,
                    NotificationType = n.NotificationType,
                    DateCreated = n.DateCreated
                };
            }
        }

        public int ID { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public NotificationType NotificationType { get; set; }

        public NotificationState NotificationState { get; set; }
    }
}