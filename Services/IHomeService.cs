using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using devReviews.API.Models.Inputs;

namespace devReviews.API.Services
{
    public interface IHomeService
    {
        Task<dynamic> GetUser(LoginUserInputModel model);
    }
}