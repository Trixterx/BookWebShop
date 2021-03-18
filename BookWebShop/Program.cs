using BookWebShop.Database;
using BookWebShop.Models;
using System;
using System.Linq;

namespace BookWebShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
        }

        public User LogIn(string username, string password, bool isAdmin)
        {

            return null;
        }
    }
}
