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
            
            var list = WebbShopAPI.GetBook(2);
            foreach (var item in list)
            {
                Console.WriteLine(item.Title);
            }
            //  Console.WriteLine(bookid);
            Console.WriteLine(WebbShopAPI.Ping(1));
        }
    }
}
