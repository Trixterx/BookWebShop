using BookWebShop;
using BookWebShop.Models;
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

        private void DeleteCategory(int adminId)
        {
            Console.WriteLine("Input Category Id you want to delete: ");
            int.TryParse(Console.ReadLine(), out var categoryId);
            api.DeleteCategory(adminId, categoryId);
        }

        private void UpdateCategory(int adminId)
        {
        }

        private void AddBookToCategory(int adminId)
        {
        }

        private void AddCategory(int adminId)
        {
        }
    }
}
