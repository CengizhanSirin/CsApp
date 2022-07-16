using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.GetOneBringComplaint
{
    public class GetOneBringComplaintQuery : IRequest<ComplaintViewDto>
    {
        public int Id { get; set; }

        public class GetOneBringComplaintQueryHandler : IRequestHandler<GetOneBringComplaintQuery, ComplaintViewDto>
        {
            private readonly IComplaintRepository _complaintRepository;
            private readonly IMapper _mapper;
            public GetOneBringComplaintQueryHandler(IComplaintRepository complaintRepository, IMapper mapper)
            {
                _complaintRepository = complaintRepository;
                _mapper = mapper;
            }

            public async Task<ComplaintViewDto> Handle(GetOneBringComplaintQuery request, CancellationToken cancellationToken)
            {
                var complaint = await _complaintRepository.GetByIdAsync(request.Id);

                var dto = _mapper.Map<ComplaintViewDto>(complaint);

                return dto;
            }
        }
    }
}
