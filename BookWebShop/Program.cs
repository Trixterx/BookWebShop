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
            // Console.WriteLine(WebbShopAPI.Login("TestCustomer", "Codic2021"));
            
            // List Book by search
            var list = WebbShopAPI.GetBook(2);
            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }

            // Bookcat by search
            var list2 = WebbShopAPI.GetCategories("Horror");
            foreach (var cate in list2)
            {
                Console.WriteLine(cate.Name);
            }

            // List all Bookcat
            var list3 = WebbShopAPI.GetCategories();
            foreach (var cate in list3)
            {
                Console.WriteLine(cate.Name);
            }
            Console.WriteLine(WebbShopAPI.Ping(1));
        }
    }
}
