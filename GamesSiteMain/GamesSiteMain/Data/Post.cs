using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }
        
        public virtual ICollection<PostTag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Tags = new List<PostTag>();
            Comments = new List<Comment>();
        }
    }
}
