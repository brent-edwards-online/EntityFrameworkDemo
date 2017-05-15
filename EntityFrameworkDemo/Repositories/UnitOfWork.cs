using EntityFrameworkDemo.Entities;
using System;

namespace EntityFrameworkDemo.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private EntityFrameworkDemoContext _context;

        public UnitOfWork(EntityFrameworkDemoContext context)
        {
            this._context = context;
        }

        public void RollBack()
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
