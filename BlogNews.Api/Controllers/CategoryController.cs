﻿using System;
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
    public class CategoryController : ControllerBase
    {
        private ICategoryRepository categoryRepository;
        public CategoryController(ICategoryRepository _categoryRepository)
        {
            categoryRepository = _categoryRepository;
        }
        // GET api/values
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Category>>> Get()
        {
            var query = categoryRepository.GetAll();
            var s = await query.ToAsyncEnumerable().ToList();
            return s;
        }

        // GET api/values
        [HttpGet]
        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            var s = await categoryRepository.GetAllAsync();
            return s;

        }

        [HttpPost]
        public async Task<int> Add(Category category)
        {
            categoryRepository.Add(category);
            var res = await categoryRepository.Save();
            return res;
        }



        [HttpPost]
        public async Task<int> Delete(Category category)
        {
            categoryRepository.Delete(category);
            var res = await categoryRepository.Save();
            return res;
        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<Category>> GetByDeneme()
        {
            var query = categoryRepository.GetAll();
            //var sonuc = await query.ToList();
            return categoryRepository.GetAll().ToList();
        }
    }
}