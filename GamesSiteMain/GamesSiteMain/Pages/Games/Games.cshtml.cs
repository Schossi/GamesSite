using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Games
{
    public class GamesModel : PageModel
    {
        public List<Game> Games { get; set; }
        
        [BindProperty]
        public List<string> Tags { get; set; }
        [BindProperty]
        public List<bool> TagStates { get; set; }

        [TempData]
        public string SelectedTags { get; set; }

        private GamesService _gamesService;

        public GamesModel(GamesService gamesService)
        {
            _gamesService = gamesService;
        }

        public void OnGet()
        {
            Tags = _gamesService.GetTags();

            if (SelectedTags == null)
                SelectedTags = string.Empty;
            string[] splitSelectedTags = SelectedTags.Split('|', StringSplitOptions.RemoveEmptyEntries);

            TagStates = Tags.Select(t => splitSelectedTags.Contains(t)).ToList();

            if (splitSelectedTags.Length == 0)
                Games = _gamesService.GetGames();
            else
                Games = _gamesService.GetGames(splitSelectedTags.ToList());
        }

        public IActionResult OnPost()
        {
            List<string> tags = new List<string>();

            for (int i = 0; i < Tags.Count; i++)
            {
                if (TagStates[i])
                    tags.Add(Tags[i]);
            }

            SelectedTags = string.Join('|', tags);

            return RedirectToPage();
        }
    }
}