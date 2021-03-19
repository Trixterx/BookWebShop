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
                User user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (user != null)
                {
                    user.SessonTimer = DateTime.Now;
                    db.Users.Update(user);
                    db.SaveChanges();
                    return user.Id;
                }
                else
                {
                    return 0;
                }
            }
        }

        public static string Logout(int userId)
        {
            using (var db = new WebbShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return string.Empty;
                }
                user.SessonTimer = default;
                db.Users.Update(user);
                db.SaveChanges();
                return "Logout";
            }
        }

        public static List<BookCategory> GetCategories()
        {
            using (var db = new WebbShopContext())
            {
                return db.BookCategories.ToList();
            }
        }

        public static List<BookCategory> GetCategories(string categoryName)
        {
            using (var db = new WebbShopContext())
            {
                return db.BookCategories.Where(bc => bc.Name.Contains(categoryName)).ToList();
            }
        }

        public static List<Book> GetCategory(int categoryId)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Category.Id == categoryId).ToList();
            }
        }

        public static List<Book> GetAvaliableBooks(int categoryId)
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Category.Id == categoryId && b.Amount > 0).ToList();
            }
        }

        public static List<Book> GetBook(int bookId) // Info book
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Id == bookId).ToList();
            }
        }

        public List<Book> GetBooks(string bookName) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Title.Contains(bookName)).ToList();
            }
        }

        public List<Book> GetAuthors(string bookByAuthor) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Author.Contains(bookByAuthor)).ToList();
            }
        }

        public bool BuyBook(int userId, int bookId) // True if book puchase is ok
        {
                return false;
        }

        public static string Ping(int userId)
        {
            using (var db = new WebbShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == userId);
                if (user == null)
                {
                    return string.Empty;
                }
                user.SessonTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return "Pong";
            }
        }

        public bool Register(string username, string password, string passwordVerify)
        {
            using (var db = new WebbShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Name == username);
                if (user == null)
                {
                    if (password == passwordVerify)
                    {
                        user.Name = username;
                        user.Password = password;
                        db.Users.Update(user);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
