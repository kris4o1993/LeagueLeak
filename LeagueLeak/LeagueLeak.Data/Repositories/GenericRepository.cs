namespace LeagueLeak.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using LeagueLeak.Common.Models;

    public class GenericRepository<T> : IRepository<T> where T : class
    {
        public GenericRepository(DbContext context)
        {
            if (context == null)
            {
                throw new ArgumentException("An instance of DbContext is required to use this repository.", "context");
            }

            this.Context = context;
            this.DbSet = this.Context.Set<T>();
        }

        protected IDbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        public virtual IQueryable<T> All()
        {
            return this.DbSet.AsQueryable();
        }

        public virtual T Find(object id)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public virtual void Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
        }

        public virtual void Delete(object id)
        {
            var entity = this.Find(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void ChangeState(T entity, EntityState state)
        {
            var entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = state;
        }

        public void Dispose()
        {
            this.Context.Dispose();
        }

        public virtual int SaveChanges()
        {
            return this.Context.SaveChanges();
        }
    }
}
