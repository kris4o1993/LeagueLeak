namespace LeagueLeak.Data
{
    using LeagueLeak.Data.Repositories;
    using LeagueLeak.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public interface IApplicationData
    {
        IRepository<ApplicationUser> ApplicationUsers { get; }

        //IRepository<ExampleModel> ExampleModels { get; }

        int SaveChanges();
    }
}
