using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Contracts.Repositories
{
    public interface IRepositoryBase<T> where T : class
    {
        IEnumerable<T> GetAll(Func<T, bool>? filter = null);
        T Find(Func<T, bool>? filter);
        Task Delete(T entity);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
    }
}
