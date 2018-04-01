using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime PublishDate { get; set; }
        public bool IsDeleted { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }

        public int? GameId { get; set; }
        public virtual Game Game { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }
}
