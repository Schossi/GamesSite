using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class PostTag
    {
        public int PostTagId { get; set; }
        public string Tag { get; set; }
        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public PostTag()
        {

        }
        public PostTag(Post post, string tag)
        {
            Post = post;
            Tag = tag;
        }
    }
}
