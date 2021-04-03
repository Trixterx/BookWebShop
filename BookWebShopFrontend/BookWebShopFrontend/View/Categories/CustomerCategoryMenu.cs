using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Categories
{
    public static class CustomerCategoryMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer Category Menu                                 |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List Categories");
            Console.WriteLine("2. Search For Category");
            Console.WriteLine("3. List Books In Category");
            Console.WriteLine("0. Back");
        }
    }
}
