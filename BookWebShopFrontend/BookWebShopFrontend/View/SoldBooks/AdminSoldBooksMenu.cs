using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.SoldBooks
{
    public static class AdminSoldBooksMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Sold Books Menu                                  |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List all Sold Books");
            Console.WriteLine("2. Money Earned");
            Console.WriteLine("3. Best Customer");
            Console.WriteLine("0. Back");
        }
    }
}
