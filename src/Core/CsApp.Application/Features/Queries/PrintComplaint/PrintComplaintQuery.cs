using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.PrintComplaint
{
    public class PrintComplaintQuery : IRequest<List<ClientWithComplaintJoinDto>>
    {
        public int Id { get; set; }
        public class PrintComplaintQueryHandler : IRequestHandler<PrintComplaintQuery, List<ClientWithComplaintJoinDto>>
        {
            private readonly IComplaintRepository _complaintRepository;

            public PrintComplaintQueryHandler(IComplaintRepository complaintRepository)
            {
                _complaintRepository = complaintRepository;

            }

            public async Task<List<ClientWithComplaintJoinDto>> Handle(PrintComplaintQuery request, CancellationToken cancellationToken)
            {

                var complaint = await _complaintRepository.Print(request.Id);
                return complaint;
            }
        }
    }
}
