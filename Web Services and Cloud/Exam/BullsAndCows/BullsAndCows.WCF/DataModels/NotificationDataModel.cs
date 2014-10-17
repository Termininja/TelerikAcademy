namespace BullsAndCows.WCF.DataModels
{
    using BullsAndCows.Models;
    using System;
    using System.Linq.Expressions;

    public class NotificationDataModel
    {
        public static Expression<Func<Notification, NotificationDataModel>> FromNotification
        {
            get
            {
                return a => new NotificationDataModel
                {
                    Content = a.Message,
                    ID = a.ID
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }
    }
}