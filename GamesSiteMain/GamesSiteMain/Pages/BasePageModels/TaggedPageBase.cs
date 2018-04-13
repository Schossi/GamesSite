using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Pages.BasePageModels
{
    public abstract class TaggedPageBase: PageModelBase
    {
        [BindProperty]
        public List<string> Tags { get; set; }
        [BindProperty]
        public List<bool> TagStates { get; set; }

        [TempData]
        public string SelectedTags { get; set; }

        public TaggedPageBase() { }

        public void OnGet()
        {
            Tags = getTags();

            if (SelectedTags == null)
                SelectedTags = string.Empty;
            string[] splitSelectedTags = SelectedTags.Split('|', StringSplitOptions.RemoveEmptyEntries);

            TagStates = Tags.Select(t => splitSelectedTags.Contains(t)).ToList();

            fillEntries(splitSelectedTags.ToList());
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

        protected abstract List<string> getTags();
        protected abstract void fillEntries(List<string> tags);
    }
}
