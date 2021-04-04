using BookWebShop.Database;
using BookWebShopFrontend.Controller;
using System;

namespace BookWebShopFrontend
{
    public static class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            var menu = new HomeController();
            menu.Start();
        }
    }
}
