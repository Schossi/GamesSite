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

        protected override async Task<List<string>> getTags()
        {
            return await _postsService.GetTags();
        }

        protected override async Task fillEntries(List<string> tags)
        {
            if (tags.Count == 0)
                Posts = await _postsService.GetPosts();
            else
                Posts = await _postsService.GetPosts(tags);

            Posts.ForEach(p => p.ShortenBody());
        }
    }
}