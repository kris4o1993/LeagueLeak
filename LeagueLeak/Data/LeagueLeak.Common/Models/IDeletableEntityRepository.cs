namespace LeagueLeak.Common.Models
{
    using LeagueLeak.Data.Repositories;
    using System.Linq;

    public interface IDeletableEntityRepository<T> : IRepository<T> where T : class
    {
        IQueryable<T> AllWithDeleted();
    }
}
