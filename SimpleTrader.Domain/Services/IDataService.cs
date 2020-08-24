using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    interface IDataService<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task Get(int id);
        Task Create(T entity);
        Task Update(int id, T entity);
        Task<bool> Delete(int id);
    }
}
