using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Pages.BasePageModels;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages
{
    public class IndexModel : PageModelBase
    {
        private GamesService _gamesService;
        private PostsService _postsService;

        public Game Game { get; set; }
        public Post Post { get; set; }

        public IndexModel(GamesService gamesService, PostsService postsService)
        {
            _gamesService = gamesService;
            _postsService = postsService;
        }

        public async Task OnGet()
        {
            Game = await _gamesService.GetLatestGame();
            Post = await _postsService.GetLatestPost();

            if (Game != null)
            {
                Game.ImagePath = $"../games/{Game.Id}.png";
                Game.ShortenDescription();
            }

            if (Post != null)
            {
                Post.ShortenBody();
            }
        }
    }
}
