using LeagueLeak.Common.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeagueLeak.Data.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private IDbSet<T> set;

        public GenericRepository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public virtual IQueryable<T> All()
        {
            return this.set;
        }

        public virtual T Find(object id)
        {
            return this.set.Find(id);
        }

        public virtual void Add(T entity)
        {
            this.ChangeState(entity, EntityState.Added);
        }

        public virtual void Update(T entity)
        {
            this.ChangeState(entity, EntityState.Modified);
        }

        public virtual T Delete(T entity)
        {
            this.ChangeState(entity, EntityState.Deleted);
            return entity;
        }

        public virtual T Delete(object id)
        {
            var entity = this.Find(id);
            this.Delete(entity);
            return entity;
        }

        public virtual void ChangeState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }

        public void Dispose()
        {
            this.context.Dispose();
        }

        public virtual int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }

}
