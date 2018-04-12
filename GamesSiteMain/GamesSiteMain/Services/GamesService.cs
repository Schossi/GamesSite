using GamesSiteMain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GamesSiteMain.Services
{
    public class GamesService
    {
        private ApplicationDbContext _dbContext;

        public GamesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public EditGame GetEditGame(int? id)
        {
            if (id.HasValue)
            {
                return new EditGame(_dbContext.Games.Where(g => g.Id == id.Value).Include(g => g.Tags).First());
            }
            else
            {
                return new EditGame();
            }
        }
        public bool SaveGame(EditGame editGame, int? id)
        {
            Game game = null;
            if (id.HasValue)
            {
                game = _dbContext.Games.Include(g => g.Tags).FirstOrDefault(g => g.Id == id.Value);
            }
            else
            {
                game = new Game();
                _dbContext.Games.Add(game);
            }

            if (game == null)
                return false;

            game.Update(editGame);
            
            _dbContext.SaveChanges();
            return true;
        }
        
        public Game GetGame(int id) => _dbContext.Games.Where(g => g.Id == id).Include(g => g.Tags).FirstOrDefault();

        public void DeleteGame(int id)
        {
            Game game = GetGame(id);
            _dbContext.Games.Remove(game);
            _dbContext.SaveChanges();
        }

        public Game GetLatestGame() => _dbContext.Games.OrderBy(g => g.PublishDate).FirstOrDefault();

        public List<Game> GetGames() => _dbContext.Games.OrderBy(g => g.PublishDate).Include(g => g.Tags).ToList();
        public List<Game> GetGames(List<string> tags)
        {
            return _dbContext.Games.Where(g => tags.All(t => g.Tags.Any(gt => gt.Tag == t))).OrderBy(g => g.PublishDate)
                .Include(g => g.Tags).ToList();
        }

        public List<string> GetTags() => _dbContext.GameTags.Select(t => t.Tag).Distinct().ToList();
    }
}
