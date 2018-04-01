using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class GameTag
    {
        public int GameTagId { get; set; }
        public string Tag { get; set; }
        public int GameId { get; set; }
        public virtual Game Game { get; set; }

        public GameTag()
        {

        }
        public GameTag(Game game,string tag)
        {
            Game = game;
            Tag = tag;
        }
    }
}
