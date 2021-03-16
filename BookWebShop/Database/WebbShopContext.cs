
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookWebShop.Database
{
    class WebbShopContext : DbContext
    {
        public string DatabaseName = "WebbShopDennisLindquist";

        public DbSet<User> Users { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<BookCategory> BookCategories { get; set; }

        public DbSet<SoldBook> SoldBooks { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer($@"Server=.\SQLEXPRESS\{DatabaseName};Integrated_Security=true;");
        }
    }
}
