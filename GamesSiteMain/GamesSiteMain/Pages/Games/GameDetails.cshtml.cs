using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using GamesSiteMain.Pages.BasePageModels;

namespace GamesSiteMain.Pages.Games
{
    public class GameDetailsModel : CommentsPageBase
    {
        [BindProperty]
        public Game Game { get; set; }

        public override PageArea Area => PageArea.Games;

        private GamesService _gamesService;

        public GameDetailsModel(GamesService gamesService, CommentsService commentsService, UserManager<ApplicationUser> userManager)
            : base(commentsService, userManager)
        {
            _gamesService = gamesService;
        }

        public override void OnGet(int id)
        {
            base.OnGet(id);

            Game = _gamesService.GetGame(id);
            Game.ImagePath = $"../../games/{Game.Id}.png";
        }
    }
}