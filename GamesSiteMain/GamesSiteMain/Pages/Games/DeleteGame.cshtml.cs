using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Pages.BasePageModels;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Games
{
    public class DeleteGameModel : PageModelBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private GamesService _gamesService;

        public Game Game { get; set; }

        public DeleteGameModel(IHostingEnvironment hostingEnvironment,GamesService gamesService)
        {
            _hostingEnvironment = hostingEnvironment;
            _gamesService = gamesService;
        }

        public void OnGet(int id)
        {
            Game = _gamesService.GetGame(id);
        }

        public IActionResult OnPost([FromRoute] int id)
        {
            _gamesService.DeleteGame(id);

            var path = Path.Combine(_hostingEnvironment.WebRootPath, "games", id + ".png");
            System.IO.File.Delete(path);

            return RedirectToPage("./Games");
        }
    }
}