using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using CsApp.Application.Models;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Commands.DeleteClient
{
    public class DeleteClientCommand : IRequest<CustomResponseDto<NoContentDto>>
    {
        public int id { get; set; }
        public class DeleteClientCommandHandler : IRequestHandler<DeleteClientCommand, CustomResponseDto<NoContentDto>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;

            public DeleteClientCommandHandler(IClientRepository clientRepository, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }

            public async Task<CustomResponseDto<NoContentDto>> Handle(DeleteClientCommand request, CancellationToken cancellationToken)
            {
                var client = await _clientRepository.GetByIdAsync(request.id);

                _clientRepository.Remove(client);

                return new CustomResponseDto<NoContentDto> { HttpStatus = 204 };
            }
        }
    }
}
