using BlogNews.Business.Abstract;
using BlogNews.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogNews.Business.Concrete
{
    public class EfUserTypeRepository : EfGenericRepository<UserType>, IUserTypeRepository
    {
        public EfUserTypeRepository(blogContext context) : base(context)
        {
        }
    }
}

