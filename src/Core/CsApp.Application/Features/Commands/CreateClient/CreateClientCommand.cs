using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Application.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Commands.CreateClient
{
    public class CreateClientCommand : IRequest<CustomResponseDto<ClientViewDto>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }

        public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, CustomResponseDto<ClientViewDto>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;

            public CreateClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<ClientViewDto>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
            {
                var client = _mapper.Map<Domain.Entities.Client>(request);

                await _clientRepository.AddAsync(client);

                var dto = _mapper.Map<ClientViewDto>(client);

                return new CustomResponseDto<ClientViewDto> { HttpStatus = 200, Data = dto };
            }
        }
    }
}
