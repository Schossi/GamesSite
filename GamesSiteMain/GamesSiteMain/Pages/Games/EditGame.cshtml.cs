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
    public class EditGameModel : PageModelBase
    {
        private GamesService _gamesService;
        private int? _id;

        public bool IsNew => _id.HasValue == false;
        [BindProperty]
        public EditGame Game { get; set; }

        public EditGameModel(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public void OnGet(int? id)
        {
            _id = id;

            Game = _gamesService.GetEditGame(id);
        }

        public IActionResult OnPost([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
                return Page();
            
            _gamesService.SaveGame(Game, id);

            return RedirectToPage("./Games");
        }
    }
}