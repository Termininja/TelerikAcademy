namespace BullsAndCows.WebAPI.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Http;

    using BullsAndCows.Data;
    using BullsAndCows.Models;
    using BullsAndCows.WebAPI.Models.DataModels;
    using Microsoft.AspNet.Identity;

    public class NotificationsController
    {
        const int defaultPageSize = 10;

        protected IGameData data;

        public NotificationsController(NotificationsData data)
        {
        }

        //POST: api/notifications
        [HttpPost]
        [Authorize]
        public IHttpActionResult Create(NotificationDataModel model)
        {
            var notification = new Notification
            {
                Message = model.Message,
                NotificationState = model.NotificationState,
                NotificationType = model.NotificationType,
                DateCreated = model.DateCreated
            };


            //this.data.Notification.Add(notification);
            //this.data.SaveChanges();

            //model.ID = notification.ID;
            //model.DateCreated = notification.DateCreated;

            return null;
        }

        //GET (public): api/notifications
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Get(0);
        }

        //GET (public): api/notifications?page=P
        [HttpGet]
        public IHttpActionResult Get(int page)
        {
            var notifications = GetAllSorted().Skip(page * defaultPageSize).Take(defaultPageSize);

            return null;
        }

        private IEnumerable<GameDataModel> GetAllSorted()
        {
            return this.data.Games.All().OrderByDescending(a => a.DateCreated).Select(GameDataModel.FromGame);
        }
    }
}
