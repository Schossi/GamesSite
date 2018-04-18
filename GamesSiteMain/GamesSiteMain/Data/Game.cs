using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GamesSiteMain.Data
{
    public class Game
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PlayLink { get; set; }
        public DateTime PublishDate { get; set; }

        public string TagsText => String.Join(' ', Tags.Select(t => t.Tag));

        [NotMapped]
        public string ImagePath { get; set; }

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
            PlayLink = editGame.PlayLink;
            PublishDate = editGame.PublishDate;

            Tags.Clear();
            if (editGame.Tags != null)
            {
                foreach (string tag in editGame.Tags.Split(' '))
                {
                    Tags.Add(new GameTag(this, tag));
                }
            }
        }

        public void ShortenDescription()
        {
            Description = Description.GetShortened();
        }
    }

    public class EditGame
    {
        public int Id { get; private set; }

        [Required]
        public string Name { get; set; }
        [DataType(DataType.Upload)]
        public IFormFile Image { get; set; }
        [DataType(DataType.Html)]
        [UIHint("tinymce_full_compressed")]
        [Required]
        public string Description { get; set; }
        [DataType(DataType.Url)]
        public string PlayLink { get; set; }

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
            PlayLink = game.PlayLink;
            PublishDate = game.PublishDate;
            Tags = string.Join(' ', game.Tags.Select(t => t.Tag));
        }
    }
}
