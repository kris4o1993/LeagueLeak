namespace LeagueLeak.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using LeagueLeak.Models;

    public interface IApplicationData
    {
        DbContext Context { get; }

        IRepository<User> Users { get; }

        IRepository<Player> Players { get; }

        IRepository<Champion> Champions { get; }

        IRepository<Spell> Spells { get; }

        IRepository<Article> Articles { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Guide> Guides { get; }

        IRepository<Feedback> Feedbacks { get; }

        int SaveChanges();
    }
}
