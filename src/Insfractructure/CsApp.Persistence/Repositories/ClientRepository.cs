using CsApp.Application.Interfaces.Repository;
using CsApp.Domain.Entities;
using CsApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsApp.Persistence.Repositories
{
    public class ClientRepository : GenericRepository<Client>, IClientRepository
    {
        public ClientRepository(AppDbContext appContext) : base(appContext)
        {
        }

        public Task<List<Client>> GetFilterAllAsync(string phoneNumber)
        {
            var clients = _appContext.Clients.AsQueryable();

            if (!string.IsNullOrEmpty(phoneNumber))
            {
                clients = clients.Where(c => c.PhoneNumber.Contains(phoneNumber));
            }

            return clients.ToListAsync();
        }
    }
}
