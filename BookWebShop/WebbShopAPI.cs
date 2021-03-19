using BookWebShop.Database;
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BookWebShop
{
    class WebbShopAPI
    {
        public static int Login(string username, string password)
        {
            using (var db = new WebbShopContext())
            {
                db.Users.Where(u => u.Name.Contains(username));
                var user = new User();


                if (username == user.Name && password == user.Password)
                {
                    try
                    {
                        if (user != null)
                        {
                            return user.Id;
                        }
                        else
                        {
                            return 0;
                        }
                    }
                    catch (Exception ex)
                    {
                        return 0;
                    }
                }
            }
            return 0;
        }

        //public DateTime Logout(int userId)
        //{

        //}

        public List<BookCategory> GetCategories()
        {
            using (var db = new WebbShopContext())
            {
                var listOfCategories = db.BookCategories.ToList();
                return listOfCategories;
            }
        }

        public IQueryable<BookCategory> GetCategories(string keyword)
        {
            using (var db = new WebbShopContext())
            {
                var listOfCategories = db.BookCategories.Where(bc => bc.Name.Contains(keyword));
                return listOfCategories;
            }
        }

        public IQueryable<Book> GetBook(int bookId) // Info books
        {
            using (var db = new WebbShopContext())
            {
                var book = db.Books.Where(b => b.Id == bookId);
                return book;
            }
        }

        public IQueryable<Book> GetBooks(string keyword) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                var listOfBooks = db.Books.Where(b => b.Title.Contains(keyword));
            return listOfBooks;
            }
        }

        public IQueryable<Book> GetAuthors(string keyword) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                var listOfBooksByAuthor = db.Books.Where(b => b.Author.Contains(keyword));
                return listOfBooksByAuthor;
            }
        }

        public bool BuyBook(int userId, int bookId) // True if book puchase is ok
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
