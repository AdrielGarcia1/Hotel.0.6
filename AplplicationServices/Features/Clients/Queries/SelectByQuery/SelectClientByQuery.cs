using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Queries.SelectByQuery
{
    public class SelectClientByQuery : IRequest<Response<ClientDTOs>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectClientByQueryHandler : IRequestHandler<SelectClientByQuery, Response<ClientDTOs>>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public SelectClientByQueryHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<Response<ClientDTOs>> IRequestHandler<SelectClientByQuery, Response<ClientDTOs>>.Handle(SelectClientByQuery request, CancellationToken cancellationToken)
        {
            var Clien = await _repository.GetByIdAsync(request.Id);
            if (Clien == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<ClientDTOs>(Clien);
                return new Response<ClientDTOs>(dto);

            }
        }
    }
}
