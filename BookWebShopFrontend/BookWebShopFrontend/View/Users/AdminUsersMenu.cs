using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Users
{
    public static class AdminUsersMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin User Menu                                        |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. List Users");
            Console.WriteLine("2. Search User");
            Console.WriteLine("3. Add User");
            Console.WriteLine("0. Back");
        }
    }
}
