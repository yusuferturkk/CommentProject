using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommentProject.EntityLayer.Concrete
{
    public class Title
    {
        public int TitleId { get; set; }
        public string TitleName { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public List<Comment> Comments { get; set; }

        public int? AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}
