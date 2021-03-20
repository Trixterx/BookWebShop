using BookWebShop.Database;
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

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
                    user.SessionTimer = DateTime.Now;
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
                user.SessionTimer = default;
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
            using (var db = new WebbShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == userId);
                Book book = db.Books.FirstOrDefault(b => b.Id == bookId);

                if (user.SessionTimer != default && user != null)
                {
                    db.SoldBooks.Add(new SoldBook { Id = book.Id, Title = book.Title, Author = book.Author, Price = book.Price, Category = book.Category, PurchaseDate = DateTime.Today, UserId = user.Id });
                    book.Amount--;
                    db.Update(user);
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
                else
                {
                return false;
                }
            }
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
                else
                {
                user.SessionTimer = DateTime.Now;
                db.Users.Update(user);
                db.SaveChanges();
                return "Pong";
                }
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

        public static bool AddBook (int adminId, int bookId, string title, string author, int price, int amount) //TODO EJ KLAR
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    Book book = db.Books.FirstOrDefault();

                    if (book.Id == bookId && book.Title == title)
                    {
                        book.Amount += amount;
                        db.Books.Update(book);
                        db.SaveChanges();
                    }
                    else
                    db.Books.Add(new Book { Id = bookId, Title = title, Author = author, Price = price, Amount = amount });
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }

        }

        public static int SetAmount(int adminId, int bookId, int amount)
        {
            if (IsAdmin(adminId))
            {

            }
            return 0;
        }

        public static List<User> ListUsers(int adminId)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.ToList();
                }
            }
            else
            {
                return null;
            }
        }

        public static List<User> FindUser(int adminId, string name)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.Where(u => u.Name.Contains(name)).ToList();
                }
            }
            else
            {
                return null;
            }
        }

        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    Book book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Title = title;
                    book.Author = author;
                    book.Price = price;
                    db.Update(book);
                    db.SaveChanges();
                    return true;                      
                }
            }
            return false;
        }

        public static bool DeleteBook(int adminId, int bookId)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    Book book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    db.Books.Remove(book);
                    db.SaveChanges();
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        public static bool AddCategory(int adminId, string categoryName)
        {
            return false;
        }

        public static bool AddBookToCategory(int adminId, int bookId, int categoryId)
        {
            return false;
        }

        public static bool UpdateCategory(int adminId, int categoryId, string categoryName)
        {
            return false;
        }

        public static bool DeleteCategory(int adminId, int categoryId)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {

                }
            }
                return false;
        }

        public static bool AddUser(int adminId, string name, string password)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    User user = db.Users.FirstOrDefault();

                    if (user.Name == name || password == null)
                    {
                        return false;
                    }
                    else
                    {
                        db.Users.Add(new User { Name = name, Password = password });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsAdmin(int adminId)
        {
            using (var db = new WebbShopContext())
            {
                User user = db.Users.FirstOrDefault(u => u.Id == adminId);

                if (user.IsAdmin)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
