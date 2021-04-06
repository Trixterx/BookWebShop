using BookWebShop;
using BookWebShop.Models;
using BookWebShopFrontend.View.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
                Console.Clear();
                ListUsers(adminId);
                AdminUsersMenu.View();
                if (int.TryParse(Console.ReadLine(), out var choice))
                {
                    switch (choice)
                    {
                        case 1:
                            Console.Clear();
                            ListUsers(adminId);
                            SearchUser(adminId);
                            Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.Clear();
                            ListUsers(adminId);
                            AddUser(adminId);
                            Thread.Sleep(2000);
                            break;
                        case 3:
                            Console.Clear();
                            ListUsers(adminId);
                            SelectUserMenu(adminId, SelectUser(adminId));
                            Thread.Sleep(2000);
                            break;
                        case 0:
                            Console.Clear();
                            keepGoing = false;
                            break;
                    }
                }
                else { Console.WriteLine("Wrong input."); }
            } while (keepGoing);
        }

        private void AddUser(int adminId)
        {
            Console.Write("\nEnter new User Username: ");
            string username = Console.ReadLine();
            Console.Write("Enter new User Password: ");
            string password = Console.ReadLine();

            if (username.Length != 0 && password.Length != 0)
            {
                try
                {
                    api.AddUser(adminId, username, password);
                }
                catch { Console.WriteLine("Something went wrong."); }
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
            Console.Write("\nSearch User By Name: ");
            string username = Console.ReadLine();

            if (username.Length != 0)
            {
                if (api.FindUser(adminId, username) != null)
                {
                    try
                    {
                        foreach (var user in api.FindUser(adminId, username))
                        {
                            Console.WriteLine($"{user.Id}. { user.Name}");
                        }
                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
            }
            else { Console.WriteLine("No input."); }
        }

        private User SelectUser(int adminId)
        {
            Console.Write("\nEnter Id of user you want to select: ");
            if (int.TryParse(Console.ReadLine(), out var selectedUserId))
            {
                if (api.ListUsers(adminId) != null)
                {
                    try
                    {
                        foreach (var user in api.ListUsers(adminId))
                        {
                            if (user.Id == selectedUserId)
                            {
                                return user;
                            }
                        }

                    }
                    catch { Console.WriteLine("Something went wrong."); }
                }
                else { Console.WriteLine("Something went wrong."); }
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
                            Console.Clear();
                            UserPromote(adminId, user);
                            Thread.Sleep(2000);
                            break;
                        case 2:
                            Console.Clear();
                            UserDemote(adminId, user);
                            Thread.Sleep(2000);
                            break;
                        case 3:
                            Console.Clear();
                            UserActivate(adminId, user);
                            Thread.Sleep(2000);
                            break;
                        case 4:
                            Console.Clear();
                            UserInactivate(adminId, user);
                            Thread.Sleep(2000);
                            break;
                        case 0:
                            Console.Clear();
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
