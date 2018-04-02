using GamesSiteMain.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Pages
{
    public interface ICommentsPage
    {
        string NewCommentText { get; set; }
        List<Comment> Comments { get; set; }
    }
}
