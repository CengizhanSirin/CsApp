using CsApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsApp.Application.Interfaces.Repository
{
    public interface IClientRepository : IGenericRepositoryAsync<Client>
    {
        Task<List<Client>> GetFilterAllAsync(string p);


    }
}
