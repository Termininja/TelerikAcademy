﻿namespace BullsAndCows.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class GameData : IGameData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public GameData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

        public IRepository<Guess> Guesses
        {
            get { return this.GetRepository<Guess>(); }
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
