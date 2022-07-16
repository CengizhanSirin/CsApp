using CsApp.Application.Dto;
using CsApp.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CsApp.Application.Interfaces.Repository
{
    public interface IComplaintRepository : IGenericRepositoryAsync<Complaint>
    {
        Task<List<ClientWithComplaintJoinDto>> GetAllJoin();

        Task<List<ClientWithComplaintJoinDto>> GetOneJoin(int id);

        Task<List<ClientWithComplaintJoinDto>> Print(int id);


    }
}
