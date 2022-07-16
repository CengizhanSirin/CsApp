using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Application.Models;
using MediatR;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Commands.UpdateComplaint
{
    public class UpdateComplaintCommand : IRequest<CustomResponseDto<NoContentDto>>
    {
        [JsonIgnore]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreateDate { get; set; }
        public int ClientId { get; set; }

        public class UpdateComplaintCommandHandler : IRequestHandler<UpdateComplaintCommand, CustomResponseDto<NoContentDto>>
        {
            private readonly IComplaintRepository _complaintRepository;
            private readonly IMapper _mapper;

            public UpdateComplaintCommandHandler(IComplaintRepository complaintRepository, IMapper mapper)
            {
                _complaintRepository = complaintRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<NoContentDto>> Handle(UpdateComplaintCommand request, CancellationToken cancellationToken)
            {
                var compliant = _mapper.Map<Domain.Entities.Complaint>(request);
                _complaintRepository.Update(compliant);

                return new CustomResponseDto<NoContentDto> { HttpStatus = 200 };
            }
        }
    }
}
