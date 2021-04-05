using BookWebShop;
using BookWebShopFrontend.View.SoldBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class SoldBooksController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void SoldBooksMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminSoldBooksMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            SoldBooks(adminId);
                            break;
                        case 2:
                            Console.Clear();
                            MoneyEarned(adminId);
                            break;
                        case 3:
                            Console.Clear();
                            BestCustomer(adminId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void BestCustomer(int adminId)
        {
            var user = api.BestCustomer(adminId);
            if(user != null)
            {
                Console.WriteLine($"The best customer is {user.Name}");
            }
            else { Console.WriteLine("Something went wrong."); }
        }

        private void MoneyEarned(int adminId)
        {
            var money = api.MoneyEarned(adminId);
            Console.WriteLine($"Total money earned is {money}kr");
        }

        private void SoldBooks(int adminId)
        {
            Console.WriteLine("List of all sold books.");
            if (api.SoldItems(adminId) != null)
            {
                foreach (var soldBook in api.SoldItems(adminId))
                {
                    Console.WriteLine($"{soldBook.Id}. {soldBook.Title} Purchasedate: {soldBook.PurchaseDate}");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }
    }
}
