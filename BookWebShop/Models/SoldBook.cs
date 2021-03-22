using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWebShop.Models
{
    public class SoldBook
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public int Price { get; set; }

        public BookCategory Category { get; set; }

        public DateTime PurchaseDate { get; set; }

        public User UsrId { get; set; }
    }
}
