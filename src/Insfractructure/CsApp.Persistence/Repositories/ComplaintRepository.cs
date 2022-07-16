using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Domain.Entities;
using CsApp.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CsApp.Persistence.Repositories
{
    public class ComplaintRepository : GenericRepository<Complaint>, IComplaintRepository
    {

        public ComplaintRepository(AppDbContext appContext) : base(appContext)
        {

        }

        public async Task<List<ClientWithComplaintJoinDto>> GetAllJoin()
        {
            return await (from client in _appContext.Clients
                          join complaint in _appContext.Complaints on client.Id equals complaint.ClientId
                          select new ClientWithComplaintJoinDto
                          {
                              Id = complaint.Id,
                              Name = client.Name,
                              Surname = client.Surname,
                              Content = complaint.Content,
                              Title = complaint.Title,
                              ClientId = complaint.ClientId,
                              CreateDate = complaint.CreateDate
                          }).ToListAsync();
        }

        public async Task<List<ClientWithComplaintJoinDto>> GetOneJoin(int id)
        {
      
            return await (from client in _appContext.Clients
                         join complaint in _appContext.Complaints
                             on client.Id equals complaint.ClientId
                         where complaint.ClientId == id
                         select new ClientWithComplaintJoinDto
                         {
                             Id = complaint.Id,
                             Name = client.Name,
                             Surname = client.Surname,
                             Content = complaint.Content,
                             Title = complaint.Title,
                             ClientId = complaint.ClientId,
                             CreateDate = complaint.CreateDate
                         }).ToListAsync();
        }

        public async Task<List<ClientWithComplaintJoinDto>> Print(int id)
        {
         
            var joinlist = _appContext.Clients.Join(_appContext.Complaints, c => c.Id, x => x.ClientId, ((client, complaint) => new ClientWithComplaintJoinDto
            {
                Id = complaint.Id,
                Name = client.Name,
                Surname = client.Surname,
                Content = complaint.Content,
                Title = complaint.Title,
                ClientId = complaint.ClientId,
                CreateDate = complaint.CreateDate
            })).Where(x=>x.Id==id).ToListAsync();

            return await joinlist;
        }


    }
}
