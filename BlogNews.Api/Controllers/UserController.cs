
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogNews.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserRepository userRepository;
        public UserController(IUserRepository _userRepository)
        {
            userRepository = _userRepository;
        }
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<User>>> Get()
        {
            var query = userRepository.GetAll();
            var s = await query.ToAsyncEnumerable().ToList();
            return s;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<User>> GetAllAsync()
        {
            var s = await userRepository.GetAllAsync();
            return s;

        }

        [HttpPost]
        public async Task<int> Add(User user)
        {
            userRepository.Add(user);
            var res = await userRepository.Save();
            return res;
        }



        [HttpPost]
        public async Task<int> Delete(User user)
        {
            userRepository.Delete(user);
            var res = await userRepository.Save();
            return res;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> GetByDeneme()
        {
            var query = userRepository.GetAll();
            //var sonuc = await query.ToList();
            return userRepository.GetAll().ToList();
        }
    }
}
 
