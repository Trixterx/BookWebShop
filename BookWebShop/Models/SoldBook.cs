using System;
using System.Collections.Generic;
using System.Text;

namespace BookWebShop.Models
{
    class SoldBook
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public int CategoryId { get; set; }

        public int PurchasedDate { get; set; }

        public int UserId { get; set; }
    }
}
