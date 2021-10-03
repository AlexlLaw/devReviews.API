using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Entity;

namespace devReviews.API.Persistence.Repositorys
{
    public static class UserRepository
    {
        public static User Get(string userName, string password)
        {
            var users = new List<User>();
            users.Add(new User { Id = 1, Username = "batman", Password = "batman", Role = "manager" });
            users.Add(new User { Id = 2, Username = "robin", Password = "robin", Role = "employee" });

            return users.Where(x => x.Username.ToLower() == userName.ToLower() && x.Password == x.Password).FirstOrDefault();
        }
    }
}