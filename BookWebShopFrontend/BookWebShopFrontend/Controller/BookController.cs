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
    public class BookController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void BookMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminBookMenu.View();
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        ListBooks();
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

            } while (keepGoing);
        }

        public void BookMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerBookMenu.View();
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        ListBooks();
                        break;
                    case 2:
                        GetBookInfo();
                        break;
                    case 3:
                        SearchBook();
                        break;
                    case 4:
                        SearchByAuthor();
                        break;
                    case 5:
                        BuyBook();
                        break;
                    case 0:
                        keepGoing = false;
                        break;
                }

            } while (keepGoing);
        }

        private void SearchBook()
        {
            throw new NotImplementedException();
        }

        private void SearchByAuthor()
        {
            throw new NotImplementedException();
        }

        private void BuyBook()
        {
            throw new NotImplementedException();
        }

        private void GetBookInfo()
        {
            Console.WriteLine("Enter number of book you want info about.");
            int.TryParse(Console.ReadLine(), out var bookId);

            foreach (var book in api.GetBook(bookId))
            {
                Console.WriteLine($"{book.Id}. Title: {book.Title} Author: {book.Author} Price: {book.Price}kr Amount: {book.Amount}st");
            }
        }

        private void ListBooks()
        {
            foreach (var book in api.GetAvaliableBooks())
            {
                Console.WriteLine($"{book.Id}. Title: {book.Title}");
            }
        }

        private void SetBookAmount(int adminId)
        {
            throw new NotImplementedException();
        }

        private void DeleteBook(int adminId)
        {
            throw new NotImplementedException();
        }

        private void UpdateBook(int adminId)
        {
        }

        public void AddBook(int adminId)
        {
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Author");
            string author = Console.ReadLine();
            Console.WriteLine("Price");
            int.TryParse(Console.ReadLine(), out var price);
            Console.WriteLine("Amount");
            int.TryParse(Console.ReadLine(), out var amount);


            if (api.AddBook(adminId, title, author, price, amount))
            {
                Console.WriteLine($"Success! {title} was added");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
        //public int SelectBook()
        //{
        //    Console.WriteLine("Select Book with Id: ");
        //    int.TryParse(Console.ReadLine(), out var choice);

        //    if (choice != 0)
        //    {
        //        var book = api.GetBook(choice);
        //        return book;
        //    }

        //}
    }
}
