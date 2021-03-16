using System;
using System.Collections.Generic;
using System.Text;

namespace BookWebShop.Models
{
    public class SoldBook
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public BookCategory CategoryId { get; set; }

        public DateTime PurchasedDate { get; set; }

        public User UserId { get; set; }
    }
}
