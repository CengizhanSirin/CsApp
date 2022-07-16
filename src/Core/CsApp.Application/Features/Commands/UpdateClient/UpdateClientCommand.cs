using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Application.Models;
using MediatR;
using System;
using System.Text.Json.Serialization;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Commands.UpdateClient
{
    public class UpdateClientCommand : IRequest<CustomResponseDto<NoContentDto>>
    {

        [JsonIgnore]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public DateTime CreateDate { get; set; }

        public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, CustomResponseDto<NoContentDto>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;

            public UpdateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<NoContentDto>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
            {
                var client = _mapper.Map<Domain.Entities.Client>(request);
                _clientRepository.Update(client);

                return new CustomResponseDto<NoContentDto> { HttpStatus = 200 };
            }
        }
    }
}
