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

namespace GamesSiteMain.Pages.Games
{
    public class GameDetailsModel : PageModel,ICommentsPage
    {
        public Game Game { get; set; }

        [Required]
        [BindProperty]
        public string NewCommentText { get; set; }
        public List<Comment> Comments { get; set; }

        private GamesService _gamesService;
        private CommentsService _commentsService;
        private UserManager<ApplicationUser> _userManager;

        public GameDetailsModel(GamesService gamesService,CommentsService commentsService,UserManager<ApplicationUser> userManager)
        {
            _gamesService = gamesService;
            _commentsService = commentsService;
            _userManager = userManager;
        }

        public void OnGet(int id)
        {
            Game = _gamesService.GetGame(id);
            Comments = _commentsService.GetGameComments(id);
        }

        public IActionResult OnPost([FromRoute] int id)
        {
            _commentsService.AddGameComment(id, _userManager.GetUserId(User), NewCommentText);

            return RedirectToPage("./GameDetails");
        }
    }
}