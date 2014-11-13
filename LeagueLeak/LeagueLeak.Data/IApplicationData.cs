namespace LeagueLeak.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LeagueLeak.Data.Repositories;
    using LeagueLeak.Models;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        IRepository<Player> Players { get; }

        IRepository<Champion> Champions { get; }

        IRepository<Spell> Spells { get; }

        IRepository<Article> Articles { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
