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
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Set Book Amount");
            Console.WriteLine("3. List Users");
            Console.WriteLine("4. Find User by Search");
            Console.WriteLine("5. Update Book");
            Console.WriteLine("6. Delete Book");
            Console.WriteLine("7. Add Category");
            Console.WriteLine("8. Add Book To Category");
            Console.WriteLine("9. Update Category");
            Console.WriteLine("10. Delete Category");
            Console.WriteLine("11. Add User");
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
