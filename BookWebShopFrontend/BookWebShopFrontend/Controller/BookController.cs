using BookWebShop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookWebShopFrontend.Controller
{
    public class BookController
    {
        WebbShopAPI api = new WebbShopAPI();

        public void BookMenuAdmin(int adminId)
        {
            bool keepGoing = true;
            do
            {
                int.TryParse(Console.ReadLine(), out var choice);
                switch (choice)
                {
                    case 1:
                        AddBook(adminId);
                        break;
                    case 2:
                        UpdateBook(adminId);
                        break;
                    case 3:
                        DeleteBook(adminId);
                        break;
                    case 4:
                        SetBookAmount(adminId);
                        break;
                    case 0:
                        keepGoing = false;
                        break;
                }

            } while (keepGoing);
        }

        private void SetBookAmount(int adminId)
        {
            throw new NotImplementedException();
        }

        private void DeleteBook(int adminId)
        {
            throw new NotImplementedException();
        }

        private void UpdateBook(int adminId)
        {
            api.UpdateBook(adminId, );
        }

        public void AddBook(int adminId)
        {
            Console.WriteLine("Title: ");
            string title = Console.ReadLine();
            Console.WriteLine("Author");
            string author = Console.ReadLine();
            Console.WriteLine("Price");
            int.TryParse(Console.ReadLine(), out var price);
            Console.WriteLine("Amount");
            int.TryParse(Console.ReadLine(), out var amount);


            if (api.AddBook(adminId, title, author, price, amount))
            {
                Console.WriteLine($"Success! {title} was added");
            }
            else
            {
                Console.WriteLine("Something went wrong.");
            }
        }
    }
}
