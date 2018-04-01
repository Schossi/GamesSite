using GamesSiteMain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Services
{
    public class GamesService
    {
        private ApplicationDbContext _dbContext;

        public GamesService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Game> GetGames() => _dbContext.Games.ToList();
    }
}
