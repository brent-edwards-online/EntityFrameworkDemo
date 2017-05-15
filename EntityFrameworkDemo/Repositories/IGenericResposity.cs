using System.Collections.Generic;

namespace EntityFrameworkDemo.Repositories
{
    public interface IGenericResposity<T> where T : class
    {
        void Create(T entity);

        T Read(object id);

        IEnumerable<T> Read();

        void Update(T entity);

        void Delete(object id);

        void Delete(T entity);
    }
}
