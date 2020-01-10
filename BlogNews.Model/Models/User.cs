using System;
using System.Collections.Generic;

namespace BlogNews.Model.Models
{
    public partial class User
    {
        public User()
        {
            News = new HashSet<News>();
        }

        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int? UserTypeId { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? LastEntryDate { get; set; }

        public UserType UserType { get; set; }
        public ICollection<News> News { get; set; }
    }
}
