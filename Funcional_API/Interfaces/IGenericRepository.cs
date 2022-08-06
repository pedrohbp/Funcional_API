using Funcional_API.Models;
using System.Collections.Generic;

namespace Funcional_API.Interfaces
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        IEnumerable<T> GetAll();
        T GetByConta(int conta);
        T Insert(T entity);
        T Update(T entity);
        int Delete(int conta);
    }
}
