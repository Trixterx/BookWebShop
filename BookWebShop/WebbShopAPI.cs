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
                return db.BookCategories.ToList();
            }
        }

        public IQueryable<BookCategory> GetCategories(string categoryName)
        {
            using (var db = new WebbShopContext())
            {
                return db.BookCategories.Where(bc => bc.Name.Contains(categoryName));
            }
        }

        public static IQueryable<Book> GetBook(int bookId) // Info books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Id == bookId);
            }
        }

        public IQueryable<Book> GetBooks(string bookName) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Title.Contains(bookName));
            }
        }

        public IQueryable<Book> GetAuthors(string bookByAuthor) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Author.Contains(bookByAuthor));
            }
        }

        public bool BuyBook(int userId, int bookId) // True if book puchase is ok
        {
                return false;
        }

        public string Ping(int userId)
        {
            using (var db = new WebbShopContext())
            {
                var user = (User)db.Users.Where(bc => bc.Id == userId);
                if (user == null)
                {
                    return null;
                }
                user.SessonTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return "Pong";
            }
        }

        public bool Register(string name, string password, bool passwordVerify)
        {
            return false;
        }
    }
}
