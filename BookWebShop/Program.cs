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
            // Mockdata
            Seeder.Seed();

            // User
            WebbShopAPI.Login("TestCustomer", "Codic2021");
            WebbShopAPI.Logout(3);
            WebbShopAPI.GetCategories();
            WebbShopAPI.GetCategories("Horror");
            WebbShopAPI.GetCategory(1);
            WebbShopAPI.GetBook(2);
            WebbShopAPI.GetBooks("I Robot");
            WebbShopAPI.GetAuthors("Stephen King");
            WebbShopAPI.BuyBook(1, 3);
            WebbShopAPI.Ping(1);
            WebbShopAPI.Register("Erik", "Hemma", "Hemma");

            /// Admin
            WebbShopAPI.AddBook(1, 3, "Titel", "Författare", 100, 1);
            WebbShopAPI.SetAmount(2, 2, 3);
            WebbShopAPI.ListUsers(1);
            WebbShopAPI.FindUser(1, "Jan");
            WebbShopAPI.UpdateBook(1, 2, "Ensam Borta", "Kungen", 200);
            WebbShopAPI.DeleteBook(1, 2);
            WebbShopAPI.AddCategory(1, "Comedy");
            WebbShopAPI.AddBookToCategory(1, 2, 4);
            WebbShopAPI.UpdateCategory(1, 2, "Läskigt");
            WebbShopAPI.DeleteCategory(1, 7);
            WebbShopAPI.AddUser(1, "Göran", "Hemligt");

            /// Admin, VG
            WebbShopAPI.SoldItems(1);
            WebbShopAPI.MoneyEarned(1);
            WebbShopAPI.BestCustomer(1);
            WebbShopAPI.Promote(1, 2);
            WebbShopAPI.Demote(1, 2);
            WebbShopAPI.ActivateUser(1, 2);
            WebbShopAPI.InactivateUser(1, 2);

        }
    }
}
