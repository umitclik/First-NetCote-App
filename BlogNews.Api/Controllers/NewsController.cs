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
    public class NewsController : ControllerBase
    {
        private INewsRepository newsRepository;
        public NewsController(INewsRepository _newsRepository)
        {
            newsRepository = _newsRepository;
        }
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<News>>> Get()
        {
            var query = newsRepository.GetAll(null, new List<string> { "Category" });
            var s = await query.ToAsyncEnumerable().ToList();


            return s;
        }


        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<News>>> Find()
        {
            var query = newsRepository.Find(x => x.Id == 1);
            var s = await query.ToAsyncEnumerable().ToList();


            return s;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<News>> GetAllAsync()
        {
            var s = await newsRepository.GetAllAsync();
            return s;

        }

        [HttpPost]
        public async Task<int> Add(News news)
        {
            newsRepository.Add(news);
            var res = await newsRepository.Save();
            return res;
        }

        [HttpPost]
        public async Task<int> Update(News news)
        {
            newsRepository.Edit(news);
            var res = await newsRepository.Save();
            return res;
        }



        [HttpPost]
        public async Task<int> Delete(News news)
        {
            newsRepository.Delete(news);
            var res = await newsRepository.Save();
            return res;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<News>> GetByDeneme()
        {
            var query = newsRepository.GetAll();
            //var sonuc = await query.ToList();
            return newsRepository.GetAll().ToList();
        }
    }
}