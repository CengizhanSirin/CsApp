using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.GetOneComplaint
{
    public class GetOneComplaintQuery : IRequest<List<ClientWithComplaintJoinDto>>
    {
        public int Id { get; set; }

        public class GetOneComplaintQueryHandler : IRequestHandler<GetOneComplaintQuery, List<ClientWithComplaintJoinDto>>
        {
            private readonly IComplaintRepository _complaintRepository;

            public GetOneComplaintQueryHandler(IComplaintRepository complaintRepository)
            {
                _complaintRepository = complaintRepository;

            }

            public async Task<List<ClientWithComplaintJoinDto>> Handle(GetOneComplaintQuery request, CancellationToken cancellationToken)
            {

                var complaint = await _complaintRepository.GetOneJoin(request.Id);
                return complaint;
            }
        }
    }
}
