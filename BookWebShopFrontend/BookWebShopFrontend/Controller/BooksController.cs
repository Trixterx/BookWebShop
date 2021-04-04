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

        public void BooksMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ListBooks(adminId);
                            break;
                        case 2:
                            AddBook(adminId);
                            break;
                        case 3:
                            UpdateBook(adminId);
                            break;
                        case 4:
                            DeleteBook(adminId);
                            break;
                        case 5:
                            SetBookAmount(adminId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        public void BookMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ListBooks(userId);
                            break;
                        case 2:
                            GetBookInfo(userId);
                            break;
                        case 3:
                            SearchBook(userId);
                            break;
                        case 4:
                            SearchByAuthor(userId);
                            break;
                        case 5:
                            BuyBook(userId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void SearchBook(int userId)
        {
            Console.WriteLine("Enter title name to search for: ");
            string bookBySearch = Console.ReadLine();
            if (bookBySearch != null)
            {
                foreach (var book in api.GetBooks(bookBySearch))
                {
                    Console.WriteLine($"{book.Id}. {book.Title} Author: {book.Author} Price: {book.Price}kr Amount: {book.Amount}st");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void SearchByAuthor(int userId)
        {
            Console.WriteLine("Enter author name to search for: ");
            string bookByAuthor = Console.ReadLine();
            if (bookByAuthor != null)
            {
                foreach (var book in api.GetAuthors(bookByAuthor))
                {
                    Console.WriteLine($"{book.Id}. {book.Title} Author: {book.Author} Price: {book.Price}kr Amount: {book.Amount}st");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void BuyBook(int userId)
        {
            Console.WriteLine("Enter Id number of the book you want to Buy.");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0)
                {
                     api.BuyBook(userId, bookId);
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }

        }

        private void GetBookInfo(int userId)
        {
            Console.WriteLine("Enter Id number of the book you want info about.");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                if (bookId != 0 && bookId > 0)
                {
                    foreach (var book in api.GetBook(bookId))
                    {
                        Console.WriteLine($"{book.Id}. {book.Title} Author: {book.Author} Price: {book.Price}kr Amount: {book.Amount}st");
                    }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void ListBooks(int userId)
        {
            if (api.GetAvaliableBooks() != null)
            {
                foreach (var book in api.GetAvaliableBooks())
                {
                    Console.WriteLine($"{book.Id}. {book.Title}");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void SetBookAmount(int adminId)
        {
            Console.WriteLine("Enter book Id number: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.WriteLine("Enter amount: ");
                if (int.TryParse(Console.ReadLine(), out var bookAmount))
                {
                    if (bookId != 0 && bookId > 0 && bookAmount != 0  && bookAmount > 0)
                    {
                        api.SetAmount(adminId, bookId, bookAmount);
                        foreach (var book in api.GetBook(bookId))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} Amount was increased to: {book.Amount}st");
                        }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input!"); }
            }
            else { Console.WriteLine("Wrong input!"); }
        }

        private void DeleteBook(int adminId)
        {
            Console.WriteLine("Enter book Id number you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                foreach (var book in api.GetBook(bookId))
                {
                    if (api.DeleteBook(adminId, bookId))
                    {
                        Console.WriteLine($"{book.Id}. {book.Title} was deleted");
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void UpdateBook(int adminId) //TODO: Kolla denna om det behövs en select här.
        {
            Console.WriteLine("Enter Id of book you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.WriteLine("Enter title: ");
                string title = Console.ReadLine();
                if (title.Length != 0)
                {
                    Console.WriteLine("Enter author");
                    string author = Console.ReadLine();
                    if (author.Length != 0)
                    {
                        Console.WriteLine("Enter price");
                        if (int.TryParse(Console.ReadLine(), out var price))
                        {
                            if (api.UpdateBook(adminId, bookId, title, author, price))
                            {
                                Console.WriteLine($"Success! The book was updated.");
                            }
                            else { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("No input."); }
                }
                else { Console.WriteLine("No input."); }
            }
        }

        private void AddBook(int adminId)
        {
            Console.WriteLine("Enter title: ");
            string title = Console.ReadLine();
            if (title.Length != 0)
            {
                Console.WriteLine("Enter author");
                string author = Console.ReadLine();
                if (author.Length != 0)
                {
                    Console.WriteLine("Enter price");
                    if (int.TryParse(Console.ReadLine(), out var price))
                    {
                        Console.WriteLine("Enter amount");
                        if (int.TryParse(Console.ReadLine(), out var amount))
                        {
                            if (api.AddBook(adminId, title, author, price, amount))
                            {
                                Console.WriteLine($"Success! {title} was added");
                            }
                            else { Console.WriteLine("Something went wrong."); }
                        }
                        else { Console.WriteLine("Wrong input."); }
                    }
                    else { Console.WriteLine("Wrong input."); }
                }
                else { Console.WriteLine("No input."); }
            }
            else { Console.WriteLine("No input."); }
        }
    }
}
