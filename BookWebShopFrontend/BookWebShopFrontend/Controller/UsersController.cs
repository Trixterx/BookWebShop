using BookWebShop;
using BookWebShopFrontend.View.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class UsersController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void UsersMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                AdminUsersMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            ListUsers(adminId);
                            break;
                        case 2:
                            SearchUser(adminId);
                            break;
                        case 3:
                            AddUser(adminId);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void AddUser(int adminId)
        {
            Console.WriteLine("Enter new User Username: ");
            string username = Console.ReadLine();
            Console.WriteLine("Enter new User Password: ");
            string password = Console.ReadLine();

            if (username.Length != 0 && password.Length != 0)
            {
                 api.AddUser(adminId, username, password);
            }
            else { Console.WriteLine("Something went wrong!"); }
        }

        private void SearchUser(int adminId)
        {
            Console.WriteLine("Search User By Name: ");
            string username = Console.ReadLine();

            if (username.Length != 0)
            {
                foreach (var user in api.FindUser(adminId, username))
                {
                    Console.WriteLine($"{user.Id}. { user.Name}");
                }
            }
            else { Console.WriteLine("No input."); }
        }

        private void ListUsers(int adminId)
        {
            if (api.ListUsers(adminId) != null)
            {
                foreach (var user in api.ListUsers(adminId))
                {
                    Console.WriteLine($"{user.Id}. {user.Name}");
                }
            }
            else { Console.WriteLine("Something went wrong."); }
        }
    }
}
