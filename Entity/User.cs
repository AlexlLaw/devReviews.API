using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace devReviews.API.Entity
{
    public class User
    {
        // public User(string userName, string password, string role)
        // {
        //     Id = Id;
        //     UserName = userName;
        //     Password = password;
        //     Role = role;
        // }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}