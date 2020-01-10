using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNews.Business.Concrete
{
    public class EfUserRepository : EfGenericRepository<User>, IUserRepository
    {
        public EfUserRepository(blogContext context) : base(context)
        {
        }
    }
}

