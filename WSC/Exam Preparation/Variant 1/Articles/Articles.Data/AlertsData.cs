﻿namespace Articles.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Articles.Data.Repositories;
    using Articles.Models;

    public class AlertsData
    {
        private ArticlesDbContext context;
        private IDictionary<Type, object> repositories;

        public AlertsData(ArticlesDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Alert> Alerts
        {
            get { return this.GetRepository<Alert>(); }
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(EFRepository<T>), context);

                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
