using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace devReviews.API.Persistence.Repositorys
{
    public class UserRepository : IUserRepository
    {
        private readonly DevReviewDbContext _DbContext;

        public UserRepository(DevReviewDbContext dbContext)
        {
          _DbContext = dbContext;   
        }

        public async Task<User> Get(string userName, string password)
        {
            return await _DbContext.Users.SingleOrDefaultAsync(x => x.Username.ToLower() == userName.ToLower() && x.Password == password);
        }
    }
}