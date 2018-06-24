using System.Collections.Generic;

namespace Repeater.ASP.Data
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        void DeleteById(int id);
        IEnumerable<T> GetAll();
        T GetById(int id);
    }
}