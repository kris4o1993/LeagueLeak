namespace LeagueLeak.Data
{
    using LeagueLeak.Data.Repositories;
    using LeagueLeak.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ApplicationData : IApplicationData
    {
        private DbContext context;
        private IDictionary<Type, object> repositories;

        public ApplicationData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public IRepository<Player> Players
        {
            get
            {
                return this.GetRepository<Player>();
            }
        }

        public IRepository<Champion> Champions
        {
            get
            {
                return this.GetRepository<Champion>();
            }
        }

        public IRepository<Spell> Spells
        {
            get
            {
                return this.GetRepository<Spell>();
            }
        }

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public IRepository<Tag> Tags
        {
            get
            {
                return this.GetRepository<Tag>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get { throw new NotImplementedException(); }
        }

    }
}
