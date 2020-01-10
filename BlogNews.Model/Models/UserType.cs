using System;
using System.Collections.Generic;

namespace BlogNews.Model.Models
{
    public partial class UserType
    {
        public UserType()
        {
            User = new HashSet<User>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }

        public ICollection<User> User { get; set; }
    }
}
