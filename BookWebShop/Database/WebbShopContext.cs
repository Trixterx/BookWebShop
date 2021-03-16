
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWebShop.Database
{
    class WebbShopContext : DbContext
    {
        public string DatabaseName { get; set; } = "WebbShopDennisLindquist";

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS;Database={DatabaseName};Trusted_Connection=true;");
        }
    }
}
