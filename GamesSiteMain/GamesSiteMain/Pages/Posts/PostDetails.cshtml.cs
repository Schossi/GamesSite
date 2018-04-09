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

namespace GamesSiteMain.Pages.Posts
{
    public class PostDetailsModel : CommentsPageBase
    {
        [BindProperty]
        public Post Post { get; set; }

        public override PageArea Area => PageArea.Posts;

        private PostsService _postsService;

        public PostDetailsModel(PostsService postsService, CommentsService commentsService, UserManager<ApplicationUser> userManager)
            : base(commentsService, userManager)
        {
            _postsService = postsService;
        }

        public override void OnGet(int id)
        {
            base.OnGet(id);

            Post = _postsService.GetPost(id);
        }
    }
}