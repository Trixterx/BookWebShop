using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Categories
{
    public static class CustomerCategoryMenu
    {
        /// <summary>
        /// Class for the view of CustomerCategoryMenu.
        /// </summary>
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Customer Category Menu                                 |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Search For Category");
            Console.WriteLine("2. List Books In Category");
            Console.WriteLine("0. Back");
        }
    }
}