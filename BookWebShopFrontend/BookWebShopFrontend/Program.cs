using BookWebShopFrontend.Controller;
using System;

namespace BookWebShopFrontend
{
    class Program
    {
        static void Main(string[] args)
        {
            var menu = new HomeController();
            menu.LogginUser();
        }
    }
}
