using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Books
{
    public static class AdminBooksMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Book Menu                                        |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List All Books");
            Console.WriteLine("2. Add Book");
            Console.WriteLine("3. Update Book");
            Console.WriteLine("4. Delete Book");
            Console.WriteLine("5. Set Amount");
            Console.WriteLine("0. Back");
        }
    }
}
