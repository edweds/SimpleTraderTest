using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleTrader.Domain.Services
{
    public interface IDataService<TValue>
    {
        Task<IEnumerable<TValue>> GetAll();
        Task<TValue> Get(int id);
        Task <TValue>Create(TValue entity);
        Task<TValue> Update(int id, TValue entity);
        Task<bool> Delete(int id);
    }
}
