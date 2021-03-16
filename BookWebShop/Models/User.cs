using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookWebShop.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public DateTime LastLogin { get; set; }

        public DateTime SessonTimer { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;

        public List<SoldBook> OwnedBooks { get; set; } = new List<SoldBook>();
    }
}
