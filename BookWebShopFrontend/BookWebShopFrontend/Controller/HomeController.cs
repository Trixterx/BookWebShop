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
                        var book = new BookController();
                        book.BookMenuAdmin(adminId);
                        break;
                    case 2:
                        var user = new UserController();
                        user.UserMenuAdmin(adminId);
                        break;
                    case 3:
                        var category = new CategoryController();
                        category.CategoryMenuAdmin(adminId);
                        break;
                    case 4:
                        break;
                    case 5:
                        break;
                    case 6:
                        break;
                    case 0:
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
