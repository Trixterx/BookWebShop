using BookWebShop.Database;
using BookWebShop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Runtime.CompilerServices;
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
                var user = db.Users.FirstOrDefault(u => u.Name == username && u.Password == password);

                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                {
                    return 0;
                }
                else if (user != null)
                {
                    user.IsActive = true;
                    user.SessionTimer = DateTime.Now;
                    user.LastLogin = DateTime.Now;
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

        public static int Logout(int userId)
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

                if (user == null)
                {
                    return 0;
                }

                user.IsActive = false;
                user.SessionTimer = default;
                db.Users.Update(user);
                db.SaveChanges();
                return 0;
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

        public static List<Book> GetBooks(string bookName) // List of matching books
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Title.Contains(bookName)).ToList();
            }
        }

        public static List<Book> GetAuthors(string bookByAuthor) // Klar
        {
            using (var db = new WebbShopContext())
            {
                return db.Books.Where(b => b.Author.Contains(bookByAuthor)).ToList();
            }
        }

        public static bool BuyBook(int userId, int bookId) // Klar
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == userId);
                var book = db.Books.FirstOrDefault(b => b.Id == bookId);
                var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == book.Id);

                if (user.SessionTimer != default && user != null)
                {
                    db.SoldBooks.Add(new SoldBook { Title = book.Title, Author = book.Author, Price = book.Price, Category = bookCategory, PurchaseDate = DateTime.Today, UserId = user.Id });
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
                var user = db.Users.FirstOrDefault(u => u.Id == userId);

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

        public static bool Register(string username, string password, string passwordVerify) // Klar
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Name == username);

                if (string.IsNullOrEmpty(username) || string.IsNullOrWhiteSpace(username) || string.IsNullOrEmpty(password) || string.IsNullOrWhiteSpace(password))
                {
                    return false;
                }
                else if (user == null)
                {
                    if (password == passwordVerify)
                    {
                        db.Users.Add(new User { Name = username, Password = password });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }
        }

        public static bool AddBook(int adminId, int bookId, string title, string author, int price, int amount) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Title == title);

                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(author) || string.IsNullOrWhiteSpace(author))
                    {
                        return false;
                    }
                    else if (book.Title == title)
                    {
                        book.Amount++;
                        db.Books.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                    else if (book == null)
                    {
                        db.Books.Add(new Book { Title = title, Author = author, Price = price, Amount = amount });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public static int SetAmount(int adminId, int bookId, int amount) // Kolla return
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Amount = amount;
                    db.Update(book);
                    db.SaveChanges();
                    return book.Amount;
                }
            }
            return 0;
        }

        public static List<User> ListUsers(int adminId) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.ToList();
                }
            }
            return new List<User>(0);
        }

        public static List<User> FindUser(int adminId, string username) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.Users.Where(u => u.Name.Contains(username)).ToList();
                }
            }
            return new List<User>(0);
        }

        public static bool UpdateBook(int adminId, int bookId, string title, string author, int price) // KLar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    if (string.IsNullOrEmpty(title) || string.IsNullOrWhiteSpace(title) || string.IsNullOrEmpty(author) || string.IsNullOrWhiteSpace(author))
                    {
                        return false;
                    }
                    else
                    {
                        book.Title = title;
                        book.Author = author;
                        book.Price = price;
                        db.Update(book);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DeleteBook(int adminId, int bookId) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Amount--;

                    if (book.Amount == 0)
                    {
                        db.Books.Remove(book);
                    }

                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool AddCategory(int adminId, string categoryName) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Name == categoryName);

                    if (string.IsNullOrEmpty(categoryName) || string.IsNullOrWhiteSpace(categoryName))
                    {
                        return false;
                    }
                    else if (categoryName == null)
                    {
                        db.BookCategories.Add(new BookCategory { Name = categoryName });
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            return false;
        }

        public static bool AddBookToCategory(int adminId, int bookId, int categoryId) // TODO: Kolla om update behövs på category
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var book = db.Books.FirstOrDefault(b => b.Id == bookId);

                    book.Category = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);
                    db.Update(book);
                    db.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public static bool UpdateCategory(int adminId, int categoryId, string categoryName) // klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);

                    if (string.IsNullOrEmpty(categoryName) || string.IsNullOrWhiteSpace(categoryName))
                    {
                        return false;
                    }
                    else
                    {
                        bookCategory.Name = categoryName;
                        db.BookCategories.Update(bookCategory);
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool DeleteCategory(int adminId, int categoryId) // klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var bookCategory = db.BookCategories.FirstOrDefault(bc => bc.Id == categoryId);

                    if (bookCategory == null)
                    {
                        return false;
                    }
                    else if (bookCategory.Books == null)
                    {
                        db.BookCategories.Remove(bookCategory);
                        db.SaveChanges();
                        return true;
                    }
                    else
                    {
                    return false;
                    }
                }
            }
            return false;
        }

        public static bool AddUser(int adminId, string username, string password) // Klar
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    var user = db.Users.FirstOrDefault(u => u.Name == username);

                    if (user.Name == username || password == null)
                    {
                        return false;
                    }
                    else if (user == null)
                    {
                        db.Users.Add(new User { Name = username, Password = password });
                        db.SaveChanges();
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool IsAdmin(int adminId) // Klar
        {
            using (var db = new WebbShopContext())
            {
                var user = db.Users.FirstOrDefault(u => u.Id == adminId);

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

        public static List<SoldBook> SoldItems(int adminId)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {
                    return db.SoldBooks.ToList();
                }
            }
            return new List<SoldBook>(0);
        }

        public static int MoneyEarned(int adminId)
        {
            if (IsAdmin(adminId))
            {
                using (var db = new WebbShopContext())
                {

                    return db.SoldBooks.Sum(sb => sb.Price);
                }
            }
            return 0;
        }
    }
}
