using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rentals.Queries.SelectByQuery
{
    public class SelectRentalByQuery : IRequest<Response<RentalDTOs>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }

    public class SelectRentalByQueryHandler : IRequestHandler<SelectRentalByQuery, Response<RentalDTOs>>
    {
        private readonly IRepository<Rental> _repository;
        private readonly IMapper _mapper;

        // Constructor que recibe las dependencias necesarias para manejar la solicitud
        public SelectRentalByQueryHandler(IRepository<Rental> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // Método para manejar la solicitud
        async Task<Response<RentalDTOs>> IRequestHandler<SelectRentalByQuery, Response<RentalDTOs>>.Handle(SelectRentalByQuery request, CancellationToken cancellationToken)
        {
            // Recuperar el cliente del repositorio utilizando el Id proporcionado en la solicitud
            var Rental = await _repository.GetByIdAsync(request.Id);

            // Verificar si el cliente existe
            if (Rental == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Realizar el mapeo del cliente a ClientDTOs utilizando el IMapper
                var dto = _mapper.Map<RentalDTOs>(Rental);

                // Devolver una respuesta que contiene el DTO del cliente
                return new Response<RentalDTOs>(dto);
            }
        }
    }
}