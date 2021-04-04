using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Categories;
using System;
using System.Collections.Generic;
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
                int.TryParse(Console.ReadLine(), out var choice);

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

            } while (keepGoing);
        }

        public void CategoryMenuCustomer(int userId)
        {
            bool keepGoing = true;
            do
            {
                CustomerCategoryMenu.View();
                int.TryParse(Console.ReadLine(), out var choice);

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

            Console.WriteLine("Search For Category: ");
            string categoryName = Console.ReadLine();
            if (categoryName.Length != 0)
            {
                foreach (var category in api.GetCategories(categoryName))
                {
                    Console.WriteLine($"{category.Id}. {category.Name}");
                }
            }
        }

        private void GetBooksInCategory(int userId)
        {
            api.Ping(userId);

            Console.WriteLine("Show Books in Category: ");
            int.TryParse(Console.ReadLine(), out var categoryId);

            if (categoryId > 0)
            {
                foreach (var book in api.GetBooksInCategory(categoryId))
                {
                    Console.WriteLine($"{book.Id}. {book.Title}");
                }
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        private void DeleteCategory(int adminId)
        {
            api.Ping(adminId);

            Console.WriteLine("Input Category Id you want to delete: ");
            int.TryParse(Console.ReadLine(), out var categoryId);
            ;
            if (categoryId > 0)
            {
                foreach (var category in api.GetCategories().Where(c => c.Id == categoryId))
                {
                    Console.WriteLine($"{category.Id}. {category.Name} was Deleted!");
                }
                api.DeleteCategory(adminId, categoryId);
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        private void UpdateCategory(int adminId)
        {
            api.Ping(adminId);

        }

        private void AddBookToCategory(int adminId)
        {
            api.Ping(adminId);
        }

        private void AddCategory(int adminId)
        {
            api.Ping(adminId);
        }
    }
}
