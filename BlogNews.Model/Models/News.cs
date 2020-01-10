using System;
using System.Collections.Generic;

namespace BlogNews.Model.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public int? CreatedUserId { get; set; }
        public int? CategoryId { get; set; }
        public int? ReadCount { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public Category Category { get; set; }
        public User CreatedUser { get; set; }
    }
}
