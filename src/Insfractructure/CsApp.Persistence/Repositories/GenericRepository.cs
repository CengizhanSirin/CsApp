using CsApp.Application.Interfaces.Repository;
using CsApp.Domain.Common;
using CsApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsApp.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepositoryAsync<T> where T : BaseEntity
    {

        protected readonly AppDbContext _appContext;
        public GenericRepository(AppDbContext appContext)
        {
            _appContext = appContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            entity.CreateDate = DateTime.Now;
            entity.UpdatedDate = DateTime.Now;
            await _appContext.Set<T>().AddAsync(entity);
            await _appContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> DeleteAsync(int id)
        {
            var result = await _appContext.Set<T>().FindAsync(id);
            _appContext.Entry(result).State = EntityState.Deleted;
            await _appContext.SaveChangesAsync();
            return result;

        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _appContext.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _appContext.Set<T>().FindAsync(id);
        }

        public void Remove(T entity)
        {
            _appContext.Set<T>().Remove(entity);
            _appContext.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.UpdatedDate = DateTime.Now;
            _appContext.Set<T>().Update(entity);
            _appContext.SaveChanges();
        }
    }
}
