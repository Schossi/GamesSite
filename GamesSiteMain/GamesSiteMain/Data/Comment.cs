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
        public ApplicationUser User { get; set; }

        public int? GameId { get; set; }
        public Game Game { get; set; }

        public int? PostId { get; set; }
        public Post Post { get; set; }
    }
}
