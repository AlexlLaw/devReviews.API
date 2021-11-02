using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Entity;


namespace devReviews.API.Persistence.Repositorys
{
    public interface IUserRepository
    {
        Task<User> Get(string userName, string password);
    }
}