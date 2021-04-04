﻿using BookWebShop;
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
                            Console.WriteLine("Bye bye");
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing) ;
        }

        private void LogginUser()
        {
            int userId;
            bool keepGoing = true;
            do
            {
                Login.View();
                Console.WriteLine("Enter Username: ");
                var username = Console.ReadLine();
                Console.WriteLine("Enter Password: ");
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
                }
            } while (keepGoing);
        }

        private void RegisterUser()
        {
            bool keepGoing = true;
            do
            {
                Register.View();
                Console.WriteLine("Enter Username: ");
                var username = Console.ReadLine();
                if (username.Length != 0)
                {
                    Console.WriteLine("Enter Password: ");
                    var password = Console.ReadLine();
                    Console.WriteLine("Verify Password: ");
                    var passwordVerify = Console.ReadLine();
                    if (password == passwordVerify)
                    {
                        if (api.Register(username, password, passwordVerify))
                        {
                            Console.WriteLine($"{username} has been registerd!");
                            keepGoing = false;
                        }
                        else { Console.WriteLine($"{username} already exist!"); }
                    }
                    else { Console.WriteLine("Passwords don't match."); }
                }
                else { Console.WriteLine("Enter Username"); }
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
                            var book = new BooksController();
                            book.BookMenuAdmin(adminId);
                            break;
                        case 2:
                            var user = new UsersController();
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
                else { Console.WriteLine("Wrong input."); }
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
                            var bookMenu = new BooksController();
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
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }
    }
}
