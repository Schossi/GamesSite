using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using GamesSiteMain.Pages.BasePageModels;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GamesSiteMain.Pages
{
    public class ErrorModel : PageModelBase
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public void OnGet()
        {
            RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier;
        }
    }
}
