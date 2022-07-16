using CsApp.Domain.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsApp.Application.Interfaces.Repository
{
    public interface IGenericRepositoryAsync<T> where T : BaseEntity
    {
        Task<List<T>> GetAllAsync();

        void Remove(T entity);

        Task<T> GetByIdAsync(int id);

        Task<T> AddAsync(T entity);

        void Update(T entity);
    }

}
