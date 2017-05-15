using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkDemo.Repositories
{
    public interface IUnitOfWork
    {
        void RollBack();

        void SaveChanges();
    }
}
