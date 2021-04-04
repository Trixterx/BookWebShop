using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Home
{
    public static class CustomerHomeMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer                                               |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Book Menu");
            Console.WriteLine("2. Category Menu");
            Console.WriteLine("0. Logout");
        }
    }
}
