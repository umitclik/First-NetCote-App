using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNews.Business.Concrete
{
    public class EfCategoryRepository : EfGenericRepository<Category>, ICategoryRepository
    {
        public EfCategoryRepository(blogContext context) : base(context)
        {
        }
    }
}
