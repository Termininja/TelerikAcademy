namespace BullsAndCows.WCF
{
    using BullsAndCows.WCF.DataModels;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    [ServiceContract]
    public interface INotificationsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/notifications")]
        IEnumerable<NotificationDataModel> GetNotifications();
    }
}
