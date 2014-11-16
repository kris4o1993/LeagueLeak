using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace LeagueLeak.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int? ArticleId { get; set; }

        public int? GuideId { get; set; }

        public int? ChampionId { get; set; }

        public DateTime DateCreated { get; set; }
    }
}
