using BookWebShop;
using BookWebShop.Models;
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
                        case 4:
                            SelectUserMenu(adminId, SelectUser(adminId));
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
        private User SelectUser(int adminId)
        {
            Console.WriteLine("Enter Id of user you want to select: ");
            if (int.TryParse(Console.ReadLine(), out var selectedUserId))
            {
                try
                {
                    var userList = api.ListUsers(adminId);
                    userList.Select(u => u.Id == selectedUserId);
                    
                    foreach (var user in userList)
                    {
                        if(user.Id == selectedUserId)
                        {
                            return user;
                        }
                    }
                     
                }
                catch { Console.WriteLine("Something went wrong."); }
            }
            else { Console.WriteLine("Wrong input."); }
            return new User();
        }

        private void SelectUserMenu(int adminId, User user)
        {
            bool keepGoing = true;
            do
            {
                AdminSelectedUserMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            UserPromote(adminId, user);
                            break;
                        case 2:
                            UserDemote(adminId, user);
                            break;
                        case 3:
                            UserActivate(adminId, user);
                            break;
                        case 4:
                            UserInactivate(adminId, user);
                            break;
                        case 0:
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void UserActivate(int adminId, User user)
        {
            try
            {
                if (api.ActivateUser(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Activated.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        private void UserDemote(int adminId, User user)
        {
            try
            {
                if (api.Demote(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Demoted.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }

        private void UserInactivate(int adminId, User user)
        {
            try
            {
                if (api.Demote(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Inactivated.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }
        private void UserPromote(int adminId, User user)
        {
            try
            {
                if (api.Promote(adminId, user.Id))
                {
                    Console.WriteLine($"Success! {user.Name} was Promoted.");
                }
                else { Console.WriteLine("Something went wrong."); }
            }
            catch
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
}
