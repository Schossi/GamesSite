using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Pages.BasePageModels;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Posts
{
    public class EditPostModel : PageModelBase
    {
        private PostsService _postsService;
        private int? _id;

        public bool IsNew => _id.HasValue == false;
        [BindProperty]
        public EditPost Post { get; set; }

        public EditPostModel(PostsService postsService)
        {
            _postsService = postsService;
        }

        public void OnGet(int? id)
        {
            _id = id;

            Post = _postsService.GetEditPost(id);
        }

        public IActionResult OnPost([FromRoute] int? id)
        {
            if (!ModelState.IsValid)
                return Page();
            
            _postsService.SavePost(Post, id);

            return RedirectToPage("./Posts");
        }
    }
}