namespace LeagueLeak.Common.Models
{
    using System.Linq;
    using LeagueLeak.Data.Repositories;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
