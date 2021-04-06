using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Categories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
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
                Console.Clear();
                GetCategories(adminId);
                AdminCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            AddCategory(adminId);
                            Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            AddBookToCategory(adminId);
                            Thread.Sleep(2000);
                            break;
                        case 3:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            UpdateCategory(adminId);
                            Thread.Sleep(2000);
                            break;
                        case 4:
                            Console.Clear();
                            api.Ping(adminId);
                            GetCategories(adminId);
                            DeleteCategory(adminId);
                            Thread.Sleep(2000);
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

        public void CategoryMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                Console.Clear();
                GetCategories(userId);
                CustomerCategoryMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            api.Ping(userId);
                            GetCategories(userId);
                            SearchCategory(userId);
                            Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.Clear();
                            api.Ping(userId);
                            GetCategories(userId);
                            GetBooksInCategory(userId);
                            Thread.Sleep(2000);
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

        private void AddBookToCategory(int adminId)
        {
            Console.Write("\nEnter Id number of the book you want to put in category: ");
            if (int.TryParse(Console.ReadLine(), out var bookId))
            {
                Console.Write("Enter Id number of the category you want to put the book in: ");
                if (int.TryParse(Console.ReadLine(), out var categoryId))
                {
                    if (api.GetCategories().Where(c => c.Id == categoryId) != null && api.GetBook(bookId) != null)
                    {
                        if (api.AddBookToCategory(adminId, bookId, categoryId))
                        {
                            foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                            {
                                foreach (var book in api.GetBook(bookId))
                                {
                                    Console.WriteLine($"Success! The book {book.Title} was added to the category {category.Name}.");
                                }
                            }
                        }
                        else { Console.WriteLine("Something went wrong."); }
                    }
                    else { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Wrong input."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void AddCategory(int adminId)
        {
            Console.Write("\nEnter category name you want to add: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                try
                {
                    if (api.AddCategory(adminId, categoryName))
                    {
                        Console.WriteLine($"Success! {categoryName} was added as a new category");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("No input."); }
        }

        private void DeleteCategory(int adminId)
        {
            Console.Write("\nEnter category Id you want to delete: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    try
                    {
                        foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                        {
                            Console.WriteLine($"Success! {category.Id}. {category.Name} was deleted!");
                        }
                        api.DeleteCategory(adminId, categoryId);
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void GetBooksInCategory(int userId)
        {
            Console.Write("\nEnter category Id you want to show books from: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (categoryId > 0)
                {
                    try
                    {
                        foreach (var book in api.GetBooksInCategory(categoryId))
                        {
                            Console.WriteLine($"{book.Id}. {book.Title}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }

        private void GetCategories(int userId)
        {
            try
            {
                Console.WriteLine($"{"Id:",-4}{"Category:",-20}\n");
                foreach (var category in api.GetCategories())
                {
                    Console.WriteLine($"{category.Id+".",-4}{category.Name,-20}");
                }
            }
            catch { Console.WriteLine("Something went wrong."); }
        }

        private void SearchCategory(int userId)
        {
            Console.Write("\nEnter category name you want to search for: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                try
                {
                    foreach (var category in api.GetCategories(categoryName))
                    {
                        Console.WriteLine($"{category.Id}. {category.Name}");
                    }
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("No input."); }
        }
        //TODO: ej klar
        private void UpdateCategory(int adminId)
        {
            Console.Write("\nEnter category Id you want to update: ");
            if (int.TryParse(Console.ReadLine(), out var categoryId))
            {
                if (api.GetCategories().Where(c => c.Id == categoryId) != null)
                {
                    Console.Write("Enter new categoryname: ");
                    string categoryName = Console.ReadLine();
                    if (categoryName.Length != 0)
                    {
                        if (api.UpdateCategory(adminId, categoryId, categoryName))
                        {
                            Console.WriteLine($"Success! The categoryname was updated to {categoryName}");
                        }
                        else { Console.WriteLine("Something went wrong and the categoryname was not updated."); }
                    }
                    else { Console.WriteLine("No input."); }
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
        }
    }
}
