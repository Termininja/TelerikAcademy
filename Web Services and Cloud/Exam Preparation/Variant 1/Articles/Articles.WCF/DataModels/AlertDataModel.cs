namespace Articles.WCF.DataModels
{
    using Articles.Models;
    using System;
    using System.Linq.Expressions;

    public class AlertDataModel
    {
        public static Expression<Func<Alert, AlertDataModel>> FromAlert
        {
            get
            {
                return a => new AlertDataModel
                {
                    Content = a.Content,
                    ID = a.ID
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }
    }
}