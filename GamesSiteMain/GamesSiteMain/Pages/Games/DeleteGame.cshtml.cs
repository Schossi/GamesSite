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
    public class DeleteGameModel : PageModelBase
    {
        public Game Game { get; set; }

        private GamesService _gamesService;

        public DeleteGameModel(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public void OnGet(int id)
        {
            Game = _gamesService.GetGame(id);
        }

        public IActionResult OnPost([FromRoute] int id)
        {
            _gamesService.DeleteGame(id);

            return RedirectToPage("./Games");
        }
    }
}