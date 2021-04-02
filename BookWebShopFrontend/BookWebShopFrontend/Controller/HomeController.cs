using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    class HomeController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void Start()
        {
            bool keepGoing = true;
            do
            {
                Home.View();
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        Register();
                        break;
                    case 2:
                        LogginUser();
                        break;
                    case 0:
                        Console.WriteLine("Bye");
                        break;
                }
            } while (keepGoing) ;
        }


        public int LogginUser()
        {
            int userId;
            bool keepGoing = true;
            do
            {
                Login.View();
                Console.WriteLine("Username: ");
                var username = Console.ReadLine();
                Console.WriteLine("Password: ");
                var password = Console.ReadLine();
                userId = api.Login(username, password);
                if (userId != 0)
                {
                    Console.WriteLine("Success! You are logged in!");
                    if (api.IsAdmin(userId))
                    {
                        AdminMenu(userId);
                    }
                    else
                    {
                        CustomerMenu(userId);
                    }
                }
                else
                {
                    Console.WriteLine("You are not logged in! Username or Password was wrong.");
                    keepGoing = true;
                }
            } while (keepGoing);

            return userId;
        }

        private void Register()
        {
            bool keepGoing = true;
            do
            {
                Console.WriteLine("Username: ");
                var username = Console.ReadLine();
                if (username.Length != 0)
                {
                    Console.WriteLine("Password: ");
                    var password = Console.ReadLine();
                    Console.WriteLine("Verify Password: ");
                    var passwordVerify = Console.ReadLine();
                    if (password == passwordVerify)
                    {
                        if (api.Register(username, password, passwordVerify))
                        {
                            Console.WriteLine($"{username} was Registerd!");
                            keepGoing = false;
                        }
                        else
                        {
                            Console.WriteLine($"{username} exists!");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Password don't match.");
                    }
                }
                else
                {
                    Console.WriteLine("Enter username");
                }
            } while (keepGoing);
        }
        private void AdminMenu(int adminId)
        {
            AdminUser.View();
            bool keepGoing = true;
            do
            {
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
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

                        break;
                    case 2:
                        break;
                    case 3:
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                    case 9:
                        break;
                    case 10:
                        break;
                    case 11:
                        break;
                    case 12:
                        break;
                    case 13:
                        break;
                    case 14:
                        break;
                    case 15:
                        break;
                    case 16:
                        break;
                    case 17:
                        break;
                    case 18:
                        break;
                }

            } while (keepGoing);
        }

        private void CustomerMenu(int userId)
        {
            bool keepGoing = true;
            do
            {
                string input;
                CustomerUser.View();
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        foreach (var category in api.GetCategories())
                        {
                            Console.WriteLine($"{category.Id}. {category.Name}");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Enter search: ");
                        input = Console.ReadLine();
                        foreach (var category in api.GetCategories(input))
                        {
                            Console.WriteLine($"{category.Id}. {category.Name}");
                        }
                        break;
                    case 3:
                        Console.WriteLine("Enter Category Id:");
                        int.TryParse(Console.ReadLine(), out var bookChoice);
                        foreach (var book in api.GetBooksInCategory(bookChoice))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title}");
                        }
                        break;
                    case 4:
                        Console.WriteLine("Enter Category Id:");
                        int.TryParse(Console.ReadLine(), out var bookChoice1);
                        foreach (var book in api.GetAvaliableBooks(bookChoice1))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title} Amount: {book.Amount}");
                        }
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 7:
                        break;
                    case 8:
                        break;
                }
            } while (keepGoing);
        }
    }
}
