﻿using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Categories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class CategoryController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void CategoryMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            AddCategory(adminId);
                            break;
                        case 2:
                            AddBookToCategory(adminId);
                            break;
                        case 3:
                            UpdateCategory(adminId);
                            break;
                        case 4:
                            DeleteCategory(adminId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        public void CategoryMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            GetCategories(userId);
                            break;
                        case 2:
                            SearchCategory(userId);
                            break;
                        case 3:
                            GetBooksInCategory(userId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void GetCategories(int userId)
        {
            api.Ping(userId);

            foreach (var category in api.GetCategories())
            {
                Console.WriteLine($"{category.Id}. {category.Name}");
            }
        }

        private void SearchCategory(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Enter category name you want to search for: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                foreach (var category in api.GetCategories(categoryName))
                {
                    Console.WriteLine($"{category.Id}. {category.Name}");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void GetBooksInCategory(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Enter category Id you want to show books from: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    foreach (var book in api.GetBooksInCategory(categoryId))
                    {
                        Console.WriteLine($"{book.Id}. {book.Title}");
                    }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void DeleteCategory(int adminId)
        {
            api.Ping(adminId);

            Console.WriteLine("Enter category Id you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                    {
                        Console.WriteLine($"{category.Id}. {category.Name} was deleted!");
                    }
                    api.DeleteCategory(adminId, categoryId);
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void UpdateCategory(int adminId)
        {
            api.Ping(adminId);

        }

        private void AddBookToCategory(int adminId)
        {
            api.Ping(adminId);

            Console.WriteLine("Enter Id number of the book you want to put in category: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.WriteLine("Enter Id number of the category you want to put the book in: ");
                if (int.TryParse(Console.ReadLine(), out var categoryId))
                {
                    if (api.AddBookToCategory(adminId, bookId, categoryId))
                    {
                        foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                        {
                            foreach (var book in api.GetBook(bookId))
                            {
                                Console.WriteLine($"Success! {book.Title} was added to category {category.Name}.");
                            }
                        }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void AddCategory(int adminId)
        {
            api.Ping(adminId);

            string categoryName = Console.ReadLine();
            
            if (categoryName.Length != 0)
            {
                if (api.AddCategory(adminId, categoryName))
                {
                    Console.WriteLine($"{categoryName} was added as a new category");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }
    }
}
