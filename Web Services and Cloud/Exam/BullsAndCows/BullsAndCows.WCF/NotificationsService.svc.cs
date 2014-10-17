namespace BullsAndCows.WCF
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    using BullsAndCows.Data;
    using BullsAndCows.WCF.DataModels;

    public class NotificationsService : INotificationsService
    {
        private NotificationsData data;

        public NotificationsService()
        {
            this.data = new NotificationsData(ApplicationDbContext.Create());
        }

        //Access by: http://localhost:8758/NotificationsService.svc/api/notifications
        public IEnumerable<NotificationDataModel> GetNotifications()
        {
            var notifications = this.data.Notifications.All().Where(a => a.DateCreated > DateTime.Now).OrderBy(a => a.DateCreated).Select(NotificationDataModel.FromNotification).ToList();

            return notifications;
        }
    }
}
