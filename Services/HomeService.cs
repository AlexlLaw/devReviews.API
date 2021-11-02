using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Persistence.Repositorys;
using devReviews.API.Models.Inputs;

namespace devReviews.API.Services
{
    public class HomeService : IHomeService
    {

        private readonly IUserRepository _UserRepository;

        public HomeService(IUserRepository IUserRepository)
        {
             _UserRepository = IUserRepository;
        }

        public async Task<dynamic> GetUser(LoginUserInputModel model) {
            return await _UserRepository.Get(model.Username, model.Password);
        }
    }
}