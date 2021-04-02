using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Home;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    class HomeController
    {
        WebbShopAPI api = new WebbShopAPI();
        
        public void Start()
        {
            var home = new Home();
            while (true)
            {
                home.View();
               
            }
        }

        public int LogginUser()
        {
            int userId;
            bool keepGoing = true;
            do
            {
                var username = Console.ReadLine();
                var password = Console.ReadLine();
                userId = api.Login(username, password);
                if (userId != 0)
                {
                    Console.WriteLine("Success! You are logged in!");
                    if (api.IsAdmin(userId))
                    {
                        AdminMenu(userId);
                    }
                    else
                    {
                        CustomerMenu(userId);
                    }
                }
                else
                {
                    Console.WriteLine("You are not logged in! Username or Password was wrong.");
                    keepGoing = true;
                }
            } while (keepGoing);

            return userId;
        }

        private void AdminMenu(int userId)
        {
            View.Home.AdminUser.View();
        }

        private void CustomerMenu(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
