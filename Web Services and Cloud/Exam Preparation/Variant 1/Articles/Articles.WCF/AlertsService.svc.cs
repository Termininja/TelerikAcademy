namespace Articles.WCF
{
    using Articles.Data;
    using Articles.WCF.DataModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertsService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlertsService.svc or AlertsService.svc.cs at the Solution Explorer and start debugging.
    public class AlertsService : IAlertsService
    {
        private AlertsData data;

        public AlertsService()
        {
            this.data = new AlertsData(ArticlesDbContext.Create());
        }

        //Access by: /AlertsService.svc/api/alerts
        public IEnumerable<AlertDataModel> GetAlerts()
        {
            var alerts = this.data.Alerts.All().Where(a => a.ExpirationDate > DateTime.Now).OrderBy(a => a.ExpirationDate).Select(AlertDataModel.FromAlert).ToList();

            return alerts;
        }
    }
}
