
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
    public class UserTypeController : ControllerBase
    {
        private IUserTypeRepository userTypeRepository;
        public UserTypeController(IUserTypeRepository _userTypeRepository)
        {
            userTypeRepository = _userTypeRepository;
        }
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<UserType>>> Get()
        {
            var query = userTypeRepository.GetAll();
            var s = await query.ToAsyncEnumerable().ToList();
            return s;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<UserType>> GetAllAsync()
        {
            var s = await userTypeRepository.GetAllAsync();
            return s;

        }

        [HttpPost]
        public async Task<int> Add(UserType userType)
        {
            userTypeRepository.Add(userType);
            var res = await userTypeRepository.Save();
            return res;
        }



        [HttpPost]
        public async Task<int> Delete(UserType userType)
        {
            userTypeRepository.Delete(userType);
            var res = await userTypeRepository.Save();
            return res;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<UserType>> GetByDeneme()
        {
            var query = userTypeRepository.GetAll();
            //var sonuc = await query.ToList();
            return userTypeRepository.GetAll().ToList();
        }
    }
}
 
