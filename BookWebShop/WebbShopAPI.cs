using BookWebShop.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Text;

namespace BookWebShop
{
    class WebbShopAPI
    {
        public int Login(string username, string password)
        {
            return 0;
        }

        //public DateTime Logout(int userId)
        //{

        //}

        public void GetCategories()
        {

        }

        public string GetCategories(string keyword)
        {
            return keyword;
        }

        public int GetBook(int bookId)
        {
            return bookId;
        }

        public string GetBooks(string keyword)
        {
            return keyword;
        }

        public string GetAuthors(string keyword)
        {
            return keyword;
        }

        public bool BuyBook(int userId, int bookId)
        {
            return false;
        }

        public int Ping(int userId)
        {
            return 0;
        }

        public bool Register(string name, string password, bool passwordVerify)
        {
            return false;
        }
    }
}
