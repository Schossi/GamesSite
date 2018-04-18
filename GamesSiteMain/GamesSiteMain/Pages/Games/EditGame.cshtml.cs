using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Pages.BasePageModels;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Games
{
    public class EditGameModel : PageModelBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private GamesService _gamesService;
        private int? _id;

        public bool IsNew => _id.HasValue == false;
        [BindProperty]
        public EditGame Game { get; set; }
        
        public EditGameModel(IHostingEnvironment hostingEnvironment,GamesService gamesService)
        {
            _hostingEnvironment = hostingEnvironment;
            _gamesService = gamesService;
        }

        public void OnGet(int? id)
        {
            _id = id;

            Game = _gamesService.GetEditGame(id);
        }

        public async Task<IActionResult> OnPost([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
                return Page();

            if (Game.Image?.Length > 0)
            {
                var path = Path.Combine(_hostingEnvironment.WebRootPath, "games", id + ".png"); 
                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    await Game.Image.CopyToAsync(fileStream);
                }
            }

            _gamesService.SaveGame(Game, id);

            return RedirectToPage("./Games");
        }
    }
}