using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogNews.Business.Concrete
{
    public class EfNewsRepository : EfGenericRepository<News>, INewsRepository
    {
        public EfNewsRepository(blogContext context) : base(context)
        {

        } 

        public List<News> GetAlls()
        {
            var resp = context.Set<News>().ToList();

            return resp;
        }
    }
}
