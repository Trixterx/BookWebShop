using BookWebShop.Database;
using BookWebShopFrontend.Controller;
using System;

namespace BookWebShopFrontend
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            var menu = new HomeController();
            menu.Start();
        }
    }
}
