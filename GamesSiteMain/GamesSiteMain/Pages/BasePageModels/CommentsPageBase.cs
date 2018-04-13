using GamesSiteMain.Data;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Pages.BasePageModels
{
    public abstract class CommentsPageBase : PageModelBase
    {
        [BindProperty]
        public Comment NewComment { get; set; } = new Comment();
        [BindProperty]
        public List<Comment> Comments { get; set; }

        public abstract PageArea Area { get; }

        private CommentsService _commentsService;
        private UserManager<ApplicationUser> _userManager;
        
        public CommentsPageBase(CommentsService commentsService, UserManager<ApplicationUser> userManager)
        {
            _commentsService = commentsService;
            _userManager = userManager;
        }

        public virtual void OnGet(int id)
        {
            switch (Area)
            {
                case PageArea.Games:
                    Comments = _commentsService.GetGameComments(id);
                    break;
                case PageArea.Posts:
                    Comments = _commentsService.GetPostComments(id);
                    break;
                default:
                    break;
            }
        }

        public IActionResult OnPostComment([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                OnGet(id);
                return Page();
            }

            int? gameId = null;
            int? postId = null;

            switch (Area)
            {
                case PageArea.Games:
                    gameId = id;
                    break;
                case PageArea.Posts:
                    postId = id;
                    break;
                default:
                    break;
            }

            _commentsService.AddComment(gameId, postId, _userManager.GetUserId(User), NewComment.Text.Replace(Environment.NewLine, "<br />"));

            OnGet(id);
            return Page();
        }

        public IActionResult OnPostDeleteComment([FromRoute] int id, [FromForm] Comment comment)
        {
            _commentsService.DeleteComment(comment.Id);

            OnGet(id);
            return RedirectToPage();
        }
    }
}
