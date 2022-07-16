using AutoMapper;
using CsApp.Application.Dto;
using CsApp.Application.Interfaces.Repository;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CsApp.Application.Features.Queries.GetAllClient
{
    public class GetAllClientQuery : IRequest<List<ClientViewDto>>
    {
        public string phoneNumber { get; set; }
        public class GetAllClientQueryHandler : IRequestHandler<GetAllClientQuery, List<ClientViewDto>>
        {
            private readonly IClientRepository _clientRepository;
            private readonly IMapper _mapper;
            public GetAllClientQueryHandler(IClientRepository clientRepository, IMapper mapper)
            {
                _clientRepository = clientRepository;
                _mapper = mapper;
            }


            public async Task<List<ClientViewDto>> Handle(GetAllClientQuery request, CancellationToken cancellationToken)
            {


                var clients = await _clientRepository.GetFilterAllAsync(request.phoneNumber);
                var dto = _mapper.Map<List<ClientViewDto>>(clients);

                return dto;
            }
        }
    }
}
