using ApplicationServices.DTOs;
using ApplicationServices.filters.ClientsF;
using ApplicationServices.filters.Rental;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.CLientS;
using ApplicationServices.Specification.RentalS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rentals.Queries.SelectAllQueries
{
    public class SelectRentalQuery : IRequest<PaginateResponse<IEnumerable<RentalDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; } // Ver

        // Filtros de búsqueda
        public string TotalCost { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectRentalQueryHandler : IRequestHandler<SelectRentalQuery, PaginateResponse<IEnumerable<RentalDTOs>>>
        {
            private readonly IRepository<Rental> _repository;
            private readonly IMapper _mapper;
            //realiza la configuración de las dependencias necesarias para que el SelectUserQueryHandler pueda
            //interactuar con la capa de persistencia y realizar el mapeo de objetos.
            public SelectRentalQueryHandler(IRepository<Rental> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<RentalDTOs>>> Handle(SelectRentalQuery request, CancellationToken cancellationToken)
            {
                // Crear el objeto de filtro de respuesta
                RentalResponseFilter ResponseFilter = new RentalResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    TotalCost = request.TotalCost,
                    IsDeleted = request.IsDeleted
                };
                // Obtener la lista de clientes utilizando la especificación paginada
                var Rental = await _repository.ListAsync(new PaginatedRentalSpecification(ResponseFilter));
                // Mapear los clientes a DTOs
                var RentalDTOs = _mapper.Map<IEnumerable<RentalDTOs>>(Rental);
                // Crear la respuesta paginada con los DTOs de clientes
                return new PaginateResponse<IEnumerable<RentalDTOs>>(RentalDTOs, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}