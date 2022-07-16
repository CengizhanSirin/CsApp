using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.GetAllComplaint
{
    public class GetAllComplaintQuery : IRequest<List<ClientWithComplaintJoinDto>>
    {
        public class GetAllComplaintQueryHandler : IRequestHandler<GetAllComplaintQuery, List<ClientWithComplaintJoinDto>>
        {
            private readonly IComplaintRepository _complaintRepository;
            private readonly IMapper _mapper;
            public GetAllComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
            {
                _complaintRepository = complaintRepository;
                _mapper = mapper;
            }

            public async Task<List<ClientWithComplaintJoinDto>> Handle(GetAllComplaintQuery request, CancellationToken cancellationToken)
            {
                var complaint = await _complaintRepository.GetAllJoin();
                return complaint;
            }
        }
    }
}
