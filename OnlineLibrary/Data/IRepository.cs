using Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace Data
{
    public interface IRepository<T> where T : class
    {
        T GetById(object id);
        List<T> GetAll();

        void Insert(T entity);
        int Count();
       
        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> Set { get; }
    }
}
