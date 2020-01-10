using System;
using System.Collections.Generic;

namespace BlogNews.Model.Models
{
    public partial class Category
    {
        public Category()
        {
            News = new HashSet<News>();
        }
         //test
        public int Id { get; set; }
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public string Url { get; set; }
        public bool? IsDelete { get; set; }

        public ICollection<News> News { get; set; }
    }
}
