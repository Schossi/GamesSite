using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string TagsText => String.Join(' ', Tags.Select(t => t.Tag));

        public virtual ICollection<PostTag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            Tags = new List<PostTag>();
            Comments = new List<Comment>();
        }

        public void Update(EditPost editPost)
        {
            Title = editPost.Title;
            Body = editPost.Body;
            PublishDate = editPost.PublishDate;

            Tags.Clear();
            foreach (string tag in editPost.Tags.Split(' '))
            {
                Tags.Add(new PostTag(this, tag));
            }
        }
    }

    public class EditPost
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Body { get; set; }
        public DateTime PublishDate { get; set; }

        public string Tags { get; set; }

        public EditPost()
        {
            Id = -1;
            PublishDate = DateTime.Now;
        }
        public EditPost(Post post)
        {
            Id = post.Id;
            Title = post.Title;
            Body = post.Body;
            PublishDate = post.PublishDate;
            Tags = string.Join(' ', post.Tags.Select(t => t.Tag));
        }
    }
}
