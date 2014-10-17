namespace Articles.WCF
{
    using Articles.WCF.DataModels;
    using System.Collections.Generic;
    using System.ServiceModel;
    using System.ServiceModel.Web;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlertsService" in both code and config file together.
    [ServiceContract]
    public interface IAlertsService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/alerts")]
        IEnumerable<AlertDataModel> GetAlerts();
    }
}
