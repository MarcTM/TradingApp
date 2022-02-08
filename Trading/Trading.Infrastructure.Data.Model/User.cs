using System;
using System.Collections.Generic;

namespace Trading.Infrastructure.Data.Model
{
    public class User
    {
        public int Id { get; set; }

        public Guid Guid { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        //public ICollection<MyStock> MyStocks { get; set; }
    }
}
