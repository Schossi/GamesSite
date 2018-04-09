using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string TagsText => String.Join(' ', Tags.Select(t => t.Tag));

        public virtual ICollection<GameTag> Tags { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public Game()
        {
            Tags = new List<GameTag>();
            Comments = new List<Comment>();
        }

        public void Update(EditGame editGame)
        {
            Name = editGame.Name;
            Description = editGame.Description;
            PublishDate = editGame.PublishDate;

            Tags.Clear();
            foreach (string tag in editGame.Tags.Split(' '))
            {
                Tags.Add(new GameTag(this, tag));
            }
        }
    }

    public class EditGame
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }

        public DateTime PublishDate { get; set; }
        public string Tags { get; set; }

        public EditGame()
        {
            Id = -1;
            PublishDate = DateTime.Now;
        }
        public EditGame(Game game)
        {
            Id = game.Id;
            Name = game.Name;
            Description = game.Description;
            PublishDate = game.PublishDate;
            Tags = string.Join(' ', game.Tags.Select(t => t.Tag));
        }
    }
}
