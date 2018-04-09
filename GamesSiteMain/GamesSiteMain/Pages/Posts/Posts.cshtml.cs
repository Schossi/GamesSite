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
    public class PostsModel : TaggedPageBase
    {
        public List<Post> Posts { get; set; }

        private PostsService _postsService;

        public PostsModel(PostsService postsService) : base()
        {
            _postsService = postsService;
        }

        protected override List<string> getTags()
        {
            return _postsService.GetTags();
        }

        protected override void fillEntries(List<string> tags)
        {
            if (tags.Count == 0)
                Posts = _postsService.GetPosts();
            else
                Posts = _postsService.GetPosts(tags);
        }
    }
}