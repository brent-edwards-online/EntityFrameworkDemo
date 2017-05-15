namespace EntityFrameworkDemo.Repositories
{
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Collections.Generic;

    public class GenericRepository<T> : IGenericResposity<T> where T : class
    {
        protected readonly DbContext _context;
        protected readonly DbSet<T> _dataset;

        public GenericRepository(DbContext context)
        {
            this._context = context;
            this._dataset = this._context.Set<T>();
        }

        public void Create(T entity)
        {
            var entityEntry = this._context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                this._dataset.Add(entity); // If entity is detacted then add 
            }
            else
            {
                entityEntry.State = EntityState.Added; // Otherwise just change entity state
            }
        }

        public void Delete(object id)
        {
            var entity = this._dataset.Find(id);
            this.Delete(entity);
        }

        public void Delete(T entity)
        {
            this.Delete(entity);
        }

        public virtual T Read(object id)
        {
            return this._dataset.Find(id);
        }

        public IEnumerable<T> Read()
        {
            return this._dataset;
        }

        public void Update(T entity)
        {
            var entityEntry = this._context.Entry(entity);
            if (entityEntry.State == EntityState.Detached)
            {
                this._dataset.Attach(entity);
            }

            entityEntry.State = EntityState.Modified;
        }
    }
}
