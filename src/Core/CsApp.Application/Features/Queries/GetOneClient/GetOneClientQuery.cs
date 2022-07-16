using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.GetOneClient
{
    public class GetOneClientQuery : IRequest<ClientViewDto>
    {
        public int Id { get; set; }

        public class GetOneClientQueryHandler : IRequestHandler<GetOneClientQuery, ClientViewDto>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;
            public GetOneClientQueryHandler(IClientRepository clientRepository, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }


            public async Task<ClientViewDto> Handle(GetOneClientQuery request, CancellationToken cancellationToken)
            {
                var clients = await _clientRepository.GetByIdAsync(request.Id);

                var dto = _mapper.Map<ClientViewDto>(clients);

                return dto;
            }
        }
    }
}
