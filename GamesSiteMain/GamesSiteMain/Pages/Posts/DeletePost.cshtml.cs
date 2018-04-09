using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Data;
using GamesSiteMain.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages.Posts
{
    public class DeletePostModel : PageModel
    {
        public Post Post { get; set; }

        private PostsService _postsService;

        public DeletePostModel(PostsService postsService)
        {
            _postsService = postsService;
        }

        public void OnGet(int id)
        {
            Post = _postsService.GetPost(id);
        }

        public IActionResult OnPost([FromRoute] int id)
        {
            _postsService.DeletePost(id);

            return RedirectToPage("./Posts");
        }
    }
}