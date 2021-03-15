using System;
using System.Collections.Generic;
using System.Text;

namespace BookWebShop.Models
{
    class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; } = "Codic2021";

        public DateTime LastLogin { get; set; }

        public DateTime SessonTimer { get; set; }

        public bool IsActive { get; set; } = true;

        public bool IsAdmin { get; set; } = false;
    }
}
