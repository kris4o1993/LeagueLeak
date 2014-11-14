namespace LeagueLeak.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using LeagueLeak.Common.Models;
    using LeagueLeak.Data.Migrations;
    using LeagueLeak.Models;
    using Microsoft.AspNet.Identity.EntityFramework;
    
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ApplicationDbContext, Configuration>());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public virtual IDbSet<Article> Articles { get; set; }

        public virtual IDbSet<Player> Players { get; set; }

        public virtual IDbSet<Champion> Champions { get; set; }

        public virtual IDbSet<Spell> Spells { get; set; }

        public virtual IDbSet<Guide> Guides { get; set; }

        public override int SaveChanges()
        {
            this.ApplyAuditInfoRules();
            return base.SaveChanges();
        }

        private void ApplyAuditInfoRules()
        {
            // Approach via @julielerman: http://bit.ly/123661P
            foreach (var entry in
                this.ChangeTracker.Entries()
                    .Where(
                        e =>
                        e.Entity is IAuditInfo && ((e.State == EntityState.Added) || (e.State == EntityState.Modified))))
            {
                var entity = (IAuditInfo)entry.Entity;

                if (entry.State == EntityState.Added)
                {
                    if (!entity.PreserveCreatedOn)
                    {
                        entity.CreatedOn = DateTime.Now;
                    }
                }
                else
                {
                    entity.ModifiedOn = DateTime.Now;
                }
            }
        }
    }
}
