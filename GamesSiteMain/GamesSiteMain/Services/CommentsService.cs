using GamesSiteMain.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GamesSiteMain.Services
{
    public class CommentsService
    {
        private ApplicationDbContext _dbContext;

        public CommentsService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Comment> GetGameComments(int gameId) => _dbContext.Comments.Where(c => c.GameId == gameId && c.IsDeleted == false).OrderByDescending(c => c.PublishDate).Include(c => c.User).ToList();
        public List<Comment> GetPostComments(int postId) => _dbContext.Comments.Where(c => c.PostId == postId && c.IsDeleted == false).OrderByDescending(c => c.PublishDate).Include(c => c.User).ToList();

        public void AddComment(int? gameId,int? postId,string userId,string text)
        {
            Comment comment = new Comment()
            {
                GameId = gameId,
                PostId = postId,
                Text = text,
                PublishDate = DateTime.UtcNow,
                UserId = userId
            };
            _dbContext.Add(comment);
            _dbContext.SaveChanges();
        }

        public void DeleteComment(int commentId)
        {
            Comment comment = _dbContext.Comments.Where(c => c.Id == commentId).First();
            comment.IsDeleted = true;
            _dbContext.SaveChanges();
        }
    }
}
