using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Home
{
    public static class AdminHomeMenu
    {
        public static void View()
        {
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("| Admin                                                  |");
            Console.WriteLine("----------------------------------------------------------");
            Console.WriteLine("1. Books Menu");
            Console.WriteLine("2. Users Menu");
            Console.WriteLine("3. Category Menu");
            Console.WriteLine("4. Sold Books Menu");
            Console.WriteLine("------------");
            Console.WriteLine("VG Functions");
            Console.WriteLine("------------");
            Console.WriteLine("15. Promote");
            Console.WriteLine("16. Demote");
            Console.WriteLine("17. Activate User");
            Console.WriteLine("18. Inactivate User");
            Console.WriteLine("0. Logout");
        }
    }
}
