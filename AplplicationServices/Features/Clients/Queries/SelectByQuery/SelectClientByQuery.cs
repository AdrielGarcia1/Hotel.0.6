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

        // Constructor que recibe las dependencias necesarias para manejar la solicitud
        public SelectClientByQueryHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Método para manejar la solicitud
        async Task<Response<ClientDTOs>> IRequestHandler<SelectClientByQuery, Response<ClientDTOs>>.Handle(SelectClientByQuery request, CancellationToken cancellationToken)
        {
            // Recuperar el cliente del repositorio utilizando el Id proporcionado en la solicitud
            var client = await _repository.GetByIdAsync(request.Id);

            // Verificar si el cliente existe
            if (client == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Realizar el mapeo del cliente a ClientDTOs utilizando el IMapper
                var dto = _mapper.Map<ClientDTOs>(client);

                // Devolver una respuesta que contiene el DTO del cliente
                return new Response<ClientDTOs>(dto);
            }
        }
    }
}