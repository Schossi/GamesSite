using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime PublishDate { get; set; }

        public virtual ICollection<GameTag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
