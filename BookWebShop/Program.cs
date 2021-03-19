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

           // Console.WriteLine(WebbShopAPI.Login("TestCustomer", "Codic2021"));


            WebbShopAPI.GetBook(9);

          //  Console.WriteLine(bookid);

        }
    }
}
