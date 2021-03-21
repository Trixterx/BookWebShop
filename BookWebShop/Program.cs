using BookWebShop.Database;
using BookWebShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookWebShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Seeder.Seed();
            WebbShopAPI.Login("TestCustomer", "Codic2021");
            WebbShopAPI.Logout(2);
            WebbShopAPI.GetCategories();
            WebbShopAPI.GetCategories("Horror");
            WebbShopAPI.GetCategory(1);
            WebbShopAPI.GetBook(2);
            WebbShopAPI.GetBooks("I Robot");
            WebbShopAPI.GetAuthors("Stephen King");
            WebbShopAPI.BuyBook(2, 3);
            WebbShopAPI.Ping(1);
            WebbShopAPI.Register("Erik", "Hemma", "Hemma");



        }
    }
}
