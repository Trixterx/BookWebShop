using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.View.Home
{
    public static class AdminUser
    {
        public static void View()
        {
            Console.WriteLine("------------");
            Console.WriteLine("Admin");
            Console.WriteLine("------------");
            Console.WriteLine("1. Books");
            Console.WriteLine("2. Users");
            Console.WriteLine("3. Category");
            Console.WriteLine("------------");
            Console.WriteLine("VG Functions");
            Console.WriteLine("------------");
            Console.WriteLine("12. List all Sold Books");
            Console.WriteLine("13. Money Earned");
            Console.WriteLine("14. Best Customer");
            Console.WriteLine("15. Promote");
            Console.WriteLine("16. Demote");
            Console.WriteLine("17. Activate User");
            Console.WriteLine("18. Inactivate User");
        }
    }
}
