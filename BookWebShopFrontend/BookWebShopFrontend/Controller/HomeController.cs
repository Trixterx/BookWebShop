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
                if(int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            RegisterUser();
                            break;
                        case 2:
                            Console.Clear();
                            LogginUser();
                            break;
                        case 0:
                            Console.WriteLine("Bye");
                            keepGoing = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            } while (keepGoing) ;
        }

        private void LogginUser()
        {
            int userId;
            bool keepGoing;
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
                    Console.Clear();
                    Console.WriteLine("Success! You are logged in!");
                    if (api.IsAdmin(userId))
                    {
                        AdminMenu(userId);
                        keepGoing = false;
                    }
                    else
                    {
                        CustomerMenu(userId);
                        keepGoing = false;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Username or Password was wrong.");
                    keepGoing = true;
                }
            } while (keepGoing);
        }

        private void RegisterUser()
        {
            bool keepGoing = true;
            do
            {
                Register.View();
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
                            Console.Clear();
                            Console.WriteLine($"{username} was Registerd!");
                            keepGoing = false;
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"{username} exists!");
                        }
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Password don't match.");
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Enter username");
                }
            } while (keepGoing);
        }

        private void AdminMenu(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminHomeMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
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
                        case 0:
                            api.Logout(adminId);
                            keepGoing = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            } while (keepGoing);
        }

        private void CustomerMenu(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerHomeMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            var bookMenu = new BookController();
                            bookMenu.BookMenuCustomer(userId);
                            break;
                        case 2:
                            var categoryMenu = new CategoryController();
                            categoryMenu.CategoryMenuCustomer(userId);
                            break;
                        case 0:
                            api.Logout(userId);
                            keepGoing = false;
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Wrong input.");
                }
            } while (keepGoing);
        }
    }
}
