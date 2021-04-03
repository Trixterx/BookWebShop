using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Books
{
    public static class CustomerBookMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer Book Menu                                     |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. Get Book Info");
            Console.WriteLine("3. Search Book");
            Console.WriteLine("4. Search Book By Author");
            Console.WriteLine("5. Buy Book");
            Console.WriteLine("0. Back");
        }
    }
}
