using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using SimpleTrader.Domain.Models;
using SimpleTrader.Domain.Services;

namespace SimpleTrader.EntityFramework.Services
{
    public class GenericDataService<TValue> : IDataService<TValue> where TValue: DomainObject
    {
        private readonly DBContextOptionsFactory _contextFactory;

        public GenericDataService(DBContextOptionsFactory contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public async Task <TValue> Create(TValue entity)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext()) 
            {
                EntityEntry<TValue> createdEntity = await context.Set<TValue>().AddAsync(entity);
                await context.SaveChangesAsync();

                return createdEntity.Entity;
            } ;
        }

        public async Task <TValue> Get(int id)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                TValue entity = await context.Set<TValue>().FirstOrDefaultAsync((a) => a.Id == id);
                
                return entity;
            };
        }

        public async Task<IEnumerable<TValue>> GetAll()
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                IEnumerable<TValue> allEntitiesList = await context.Set<TValue>().ToListAsync();

                return allEntitiesList;
            };
        }

        public async Task <TValue> Update(int id, TValue entity)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                entity.Id = id;
                context.Set<TValue>().Update(entity);
                await context.SaveChangesAsync();
                return entity;
            };
        }
        public async Task<bool> Delete(int id)
        {
            using (SimpleTraderDbContext context = _contextFactory.CreateDbContext())
            {
                TValue entity = await context.Set<TValue>().FirstOrDefaultAsync((a) => a.Id == id);
                context.Set<TValue>().Remove(entity);
                await context.SaveChangesAsync();

                return true;
            };
        }
    }
}
