using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Application.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Commands.CreateComplaint
{
    public class CreateComplaintCommand : IRequest<CustomResponseDto<ComplaintViewDto>>
    {
        public string Title { get; set; }

        public string Content { get; set; }

        public int ClientId { get; set; }

        public class CreateComplaintCommandHandler : IRequestHandler<CreateComplaintCommand, CustomResponseDto<ComplaintViewDto>>
        {
            private readonly IComplaintRepository _complaintRepository;
            private readonly IMapper _mapper;

            public CreateComplaintCommandHandler(IComplaintRepository complaintRepository, IMapper mapper)
            {
                _complaintRepository = complaintRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<ComplaintViewDto>> Handle(CreateComplaintCommand request, CancellationToken cancellationToken)
            {
                var complaint = _mapper.Map<Domain.Entities.Complaint>(request);
          
                await _complaintRepository.AddAsync(complaint);

                var dto = _mapper.Map<ComplaintViewDto>(complaint);

                return new CustomResponseDto<ComplaintViewDto> { HttpStatus = 200, Data = dto };

            }
        }
    }
}
