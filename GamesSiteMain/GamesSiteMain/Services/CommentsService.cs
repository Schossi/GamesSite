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

        public List<Comment> GetGameComments(int gameId)
        {
            return _dbContext.Comments.Where(c => c.GameId == gameId).OrderBy(c => c.PublishDate).Include(c=>c.User).ToList();
        }

        public void AddGameComment(int gameId,string userId,string text)
        { 
            Comment comment = new Comment()
            {
                GameId = gameId,
                Text = text,
                PublishDate = DateTime.UtcNow,
                UserId = userId
            };
            _dbContext.Add(comment);
            _dbContext.SaveChanges();
        }
    }
}
