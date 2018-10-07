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
        public string RootPath = "../";

        public List<Game> Games { get; set; }
        
        private GamesService _gamesService;

        public GamesModel(GamesService gamesService):base()
        {
            _gamesService = gamesService;
        }
        
        protected override async Task<List<string>> getTags()
        {
            return await _gamesService.GetTags();
        }

        protected override async Task fillEntries(List<string> tags)
        {
            if (tags.Count == 0)
                Games = await _gamesService.GetGames();
            else
                Games = await _gamesService.GetGames(tags);

            Games.ForEach(g => g.ShortenDescription());
            Games.ForEach(g => g.ImagePath = $"../../games/{g.Id}.png");
        }
    }
}