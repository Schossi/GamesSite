using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Pages.BasePageModels;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Games
{
    public class GamesModel : TaggedPageBase
    {
        public List<Game> Games { get; set; }
        
        private GamesService _gamesService;

        public GamesModel(GamesService gamesService):base()
        {
            _gamesService = gamesService;
        }
        
        protected override List<string> getTags()
        {
            return _gamesService.GetTags();
        }

        protected override void fillEntries(List<string> tags)
        {
            if (tags.Count == 0)
                Games = _gamesService.GetGames();
            else
                Games = _gamesService.GetGames(tags);
        }
    }
}