using BookWebShopFrontend.View.SoldBooks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class SoldBooksController
    {
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
                            SoldBooks(adminId);
                            break;
                        case 2:
                            MoneyEarned(adminId);
                            break;
                        case 3:
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
            throw new NotImplementedException();
        }

        private void MoneyEarned(int adminId)
        {
            throw new NotImplementedException();
        }

        private void SoldBooks(int adminId)
        {
            throw new NotImplementedException();
        }
    }
}
