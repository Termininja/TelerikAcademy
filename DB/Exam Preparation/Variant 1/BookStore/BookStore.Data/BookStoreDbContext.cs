﻿namespace BookStore.Data
{
    using System.Data.Entity;

    using BookStore.Models;
    using BookStore.Data.Migrations;

    public class BookStoreDbContext : DbContext
    {
        public BookStoreDbContext()
            : base("BookStore")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BookStoreDbContext, Configuration>());
        }

        public IDbSet<Author> Authors { get; set; }

        public IDbSet<Book> Books { get; set; }

        public IDbSet<Review> Reviews { get; set; }
    }
}