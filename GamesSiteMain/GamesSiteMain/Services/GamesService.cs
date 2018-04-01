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
                return new EditGame(_dbContext.Games.Where(g => g.Id == id.Value).First());
            }
            else
            {
                return new EditGame();
            }
        }
        public bool SaveGame(EditGame editGame)
        {
            Game game = null;
            if (editGame.Id >= 0)
            {
                game = _dbContext.Games.FirstOrDefault(g => g.Id == editGame.Id);
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

        public List<Game> GetGames() => _dbContext.Games.OrderBy(g => g.PublishDate).Include(g => g.Tags).ToList();
        public List<Game> GetGames(List<string> tags)
        {
            return _dbContext.Games.Where(g => tags.All(t => g.Tags.Any(gt => gt.Tag == t))).OrderBy(g => g.PublishDate)
                .Include(g => g.Tags).ToList();
        }

        public List<string> GetTags() => _dbContext.GameTags.Select(t => t.Tag).Distinct().ToList();
    }
}
