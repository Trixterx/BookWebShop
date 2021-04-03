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
            Console.WriteLine("2. List Categories with Search");
            Console.WriteLine("3. List of Books in Category");
            Console.WriteLine("4. List of Books");
            Console.WriteLine("5. Info about book");
            Console.WriteLine("6. List Books with search");
            Console.WriteLine("7. List Books with Author Search");
            Console.WriteLine("8. Buy Book");
        }
    }
}
