using GamesSiteMain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GamesSiteMain.Services
{
    public class PostsService
    {
        private ApplicationDbContext _dbContext;

        public PostsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EditPost GetEditPost(int? id)
        {
            if (id.HasValue)
            {
                return new EditPost(_dbContext.Posts.Where(g => g.Id == id.Value).Include(g => g.Tags).First());
            }
            else
            {
                return new EditPost();
            }
        }
        public bool SavePost(EditPost editPost, int? id)
        {
            Post post = null;
            if (id.HasValue)
            {
                post = _dbContext.Posts.Include(g => g.Tags).FirstOrDefault(g => g.Id == id.Value);
            }
            else
            {
                post = new Post();
                _dbContext.Posts.Add(post);
            }

            if (post == null)
                return false;

            post.Update(editPost);

            _dbContext.SaveChanges();

            editPost.Id = post.Id;

            return true;
        }

        public Post GetPost(int id) => _dbContext.Posts.Where(g => g.Id == id).Include(g => g.Tags).FirstOrDefault();

        public void DeletePost(int id)
        {
            Post post = GetPost(id);
            _dbContext.Posts.Remove(post);
            _dbContext.SaveChanges();
        }

        public async Task<Post> GetLatestPost() => await _dbContext.Posts.OrderByDescending(g => g.PublishDate).FirstOrDefaultAsync();

        public async Task<List<Post>> GetPosts() => await _dbContext.Posts.OrderByDescending(g => g.PublishDate).Include(g => g.Tags).ToListAsync();
        public async Task<List<Post>> GetPosts(List<string> tags)
        {
            return await _dbContext.Posts.Where(g => tags.All(t => g.Tags.Any(gt => gt.Tag == t))).OrderByDescending(g => g.PublishDate)
                .Include(g => g.Tags).ToListAsync();
        }

        public async Task<List<string>> GetTags() => await _dbContext.PostTags.Select(t => t.Tag).Distinct().ToListAsync();
    }
}
