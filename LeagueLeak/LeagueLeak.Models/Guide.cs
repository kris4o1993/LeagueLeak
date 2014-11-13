namespace LeagueLeak.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Guide
    {
        private ICollection<Spell> spells;

        public Guide()
        {
            this.spells = new HashSet<Spell>();
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public int UserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public int ChampionId { get; set; }

        public virtual Champion Champion { get; set; }

        public virtual ICollection<Spell> Spells
        {
            get { return this.spells; }
            set { this.spells = value; }
        }
    }
}
