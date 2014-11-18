namespace LeagueLeak.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LeagueLeak.Data.Migrations;
    using LeagueLeak.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Comment> Comments { get; set; }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Champion> Champions { get; set; }

        public virtual IDbSet<Spell> Spells { get; set; }

        public virtual IDbSet<Guide> Guides { get; set; }

        public virtual IDbSet<Feedback> Feedbacks { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
