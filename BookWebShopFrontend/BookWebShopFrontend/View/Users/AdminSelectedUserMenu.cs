﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Users
{
    public static class AdminSelectedUserMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin Selected User Menu                               |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Promote user");
            Console.WriteLine("2. Demote user");
            Console.WriteLine("3. Activate user");
            Console.WriteLine("4. Inactivate user");
            Console.WriteLine("0. Back");
        }
    }
}
