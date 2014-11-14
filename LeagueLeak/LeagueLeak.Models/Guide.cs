namespace LeagueLeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guide
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public int SpellId { get; set; }

        public virtual Spell Spell { get; set; }
    }
}
