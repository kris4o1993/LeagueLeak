namespace LeagueLeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guide
    {
        private ICollection<Comment> comments;

        public Guide()
        {
            this.comments = new HashSet<Comment>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(3)]
        [MaxLength(30)]
        public string Title { get; set; }

        [MinLength(10)]
        public string Content { get; set; }

        public string AuthorId { get; set; }

        public virtual User Author { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public int SpellId { get; set; }

        public virtual Spell Spell { get; set; }

        public virtual ICollection<Comment> Comments
        {
            get { return this.comments; }
            set { this.comments = value; }
        }
    }
}
