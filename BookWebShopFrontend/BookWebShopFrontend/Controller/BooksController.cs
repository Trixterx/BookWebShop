using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Books;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class BooksController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void BookMenuCustomer(int userId) //TODO: Här är jag..
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                ListBooks(userId);
                CustomerBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListBooks(userId);
                            GetBookInfo(userId);
                            break;
                        case 2:
                            Console.Clear();
                            ListBooks(userId);
                            SearchBook(userId);
                            break;
                        case 3:
                            Console.Clear();
                            ListBooks(userId);
                            SearchByAuthor(userId);
                            break;
                        case 4:
                            Console.Clear();
                            ListBooks(userId);
                            BuyBook(userId);
                            break;
                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        public void BooksMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                ListBooks(adminId);
                AdminBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListBooks(adminId);
                            AddBook(adminId);
                            break;
                        case 2:
                            Console.Clear();
                            ListBooks(adminId);
                            UpdateBook(adminId);
                            break;
                        case 3:
                            Console.Clear();
                            ListBooks(adminId);
                            DeleteBook(adminId);
                            break;
                        case 4:
                            Console.Clear();
                            ListBooks(adminId);
                            SetBookAmount(adminId);
                            break;
                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void AddBook(int adminId)
        {
            Console.Write("\nEnter title: ");
            string title = Console.ReadLine();
            if (title.Length != 0)
            {
                Console.Write("Enter author");
                string author = Console.ReadLine();
                if (author.Length != 0)
                {
                    Console.Write("Enter price: ");
                    if (int.TryParse(Console.ReadLine(), out var price))
                    {
                        Console.Write("Enter amount: ");
                        if (int.TryParse(Console.ReadLine(), out var amount))
                        {
                            try
                            {
                                if (api.AddBook(adminId, title, author, price, amount))
                                {
                                    Console.WriteLine($"Success! {title} was added");
                                }
                                else { Console.WriteLine("Something went wrong."); }
                            }
                            catch { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("Wrong input."); }
                }
                else { Console.WriteLine("No input."); }
            }
            else { Console.WriteLine("No input."); }
        }

        private void BuyBook(int userId)
        {
            Console.Write("\nEnter Id number of the book you want to Buy: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0)
                {
                    try
                    {
                        if (api.BuyBook(userId, bookId))
                        {
                            Console.WriteLine("Success!");
                        }
                        else { Console.WriteLine("Something went wrong."); }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }

        }

        private void DeleteBook(int adminId)
        {
            Console.Write("\nEnter book Id number you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                try
                {
                    if (api.DeleteBook(adminId, bookId))
                    {
                        Console.WriteLine($"Success! Book was deleted.");
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void GetBookInfo(int userId)
        {
            Console.Write("\nEnter Id number of the book you want info about: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0 && bookId > 0)
                {
                    try
                    {
                        Console.WriteLine($"{"Id",-3}{"Title",-20}{"CatId",-6}{"CatName",-15}{"Author",-20}{"Price",-6}{"Amount",-7}\n");
                        foreach (var book in api.GetBook(bookId))
                        {
                            Console.WriteLine($"{book.Id,-3}{book.Title,-20}{book.Category.Id,-6}{book.Category.Name,-15}{book.Author,-20}{book.Price,-6}{book.Amount,-7}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void ListBooks(int userId)
        {
            if (api.GetAvaliableBooks() != null)
            {
                try
                {
                    Console.WriteLine($"{"Id",-3}{"Title",-20}{"Author",-20}{"Price",-6}{"Amount",-7}\n");
                    foreach (var book in api.GetAvaliableBooks())
                    {
                        Console.WriteLine($"{book.Id,-3}{book.Title,-20}{book.Author,-20}{book.Price,-6}{book.Amount,-7}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void SearchBook(int userId)
        {
            Console.Write("\nEnter title name to search for: ");
            string bookBySearch = Console.ReadLine();
            if (bookBySearch != null)
            {
                try
                {
                    Console.WriteLine($"{"Id",-3}{"Title",-20}{"CatId",-6}{"CatName",-15}{"Author",-20}{"Price",-6}{"Amount",-7}\n");
                    foreach (var book in api.GetBooks(bookBySearch))
                    {
                        Console.WriteLine($"{book.Id,-3}{book.Title,-20}{book.Category.Id,-6}{book.Category.Name,-15}{book.Author,-20}{book.Price,-6}{book.Amount,-7}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void SearchByAuthor(int userId)
        {
            Console.Write("\nEnter author name to search for: ");
            string bookByAuthor = Console.ReadLine();
            if (bookByAuthor != null && api.GetAuthors(bookByAuthor) != null)
            {
                try
                {
                    Console.WriteLine($"{"Id",-3}{"Title",-20}{"CatId",-6}{"CatName",-15}{"Author",-20}{"Price",-6}{"Amount",-7}\n");
                    foreach (var book in api.GetAuthors(bookByAuthor))
                    {
                        Console.WriteLine($"{book.Id,-3}{book.Title,-20}{book.Category.Id,-6}{book.Category.Name,-15}{book.Author,-20}{book.Price,-6}{book.Amount,-7}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void SetBookAmount(int adminId)
        {
            Console.Write("\nEnter book Id number: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.Write("Enter amount: ");
                if (int.TryParse(Console.ReadLine(), out var bookAmount))
                {
                    if (bookId != 0 && bookId > 0 && bookAmount != 0  && bookAmount > 0)
                    {
                        try
                        {
                            api.SetAmount(adminId, bookId, bookAmount);
                            foreach (var book in api.GetBook(bookId))
                            {
                                Console.WriteLine($"{book.Id}. {book.Title} Amount was increased to: {book.Amount}st");
                            }
                        }
                        catch { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input!"); }
            }
            else { Console.WriteLine("Wrong input!"); }
        }

        private void UpdateBook(int adminId) //TODO: Kolla denna om det behövs en select här.
        {
            Console.Write("\nEnter Id of book you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.Write("Enter title: ");
                string title = Console.ReadLine();
                if (title.Length != 0)
                {
                    Console.Write("Enter author: ");
                    string author = Console.ReadLine();
                    if (author.Length != 0)
                    {
                        Console.Write("Enter price: ");
                        if (int.TryParse(Console.ReadLine(), out var price))
                        {
                            try
                            {
                                if (api.UpdateBook(adminId, bookId, title, author, price))
                                {
                                    Console.WriteLine("Success! The book was updated.");
                                }
                                else { Console.WriteLine("Something went wrong."); }
                            }
                            catch { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("No input."); }
                }
                else { Console.WriteLine("No input."); }
            }
        }
    }
}
