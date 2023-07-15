using ApplicationServices.DTOs;
using ApplicationServices.filters.Receptionist;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.ReceptionistS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Recepcionists.Queries.SelectAllQueries
{
    // Comando para realizar una consulta de todos los recepcionistas
    public class SelectReceptionistQuery : IRequest<PaginateResponse<IEnumerable<ReceptionistDTOs>>>
    {
        public int PageNumber { get; set; } // Número de página para la paginación
        public int PageSize { get; set; } // Tamaño de página para la paginación
        public string? NameRecep { get; set; } // Nombre del recepcionista para filtrar la consulta
        public string? LastNameRecep { get; set; } // Apellido del recepcionista para filtrar la consulta
        public bool IsDeleted { get; set; } // Indicador de eliminación para filtrar la consulta
    }
    public class SelectReceptionistQueryHandler : IRequestHandler<SelectReceptionistQuery, PaginateResponse<IEnumerable<ReceptionistDTOs>>>
    {
        private readonly IRepository<Receptionist> _repository;
        private readonly IMapper _mapper;
        public SelectReceptionistQueryHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginateResponse<IEnumerable<ReceptionistDTOs>>> Handle(SelectReceptionistQuery request, CancellationToken cancellationToken)
        {
            // Crear un filtro de respuesta basado en los parámetros de la consulta
            ReceptionistResponseFilter ResponseFilter = new ReceptionistResponseFilter()
            {
                PageSize = request.PageSize, // Tamaño de página para la paginación
                PageNumber = request.PageNumber, // Número de página para la paginación
                NameRecep = request.NameRecep, // Nombre del recepcionista para filtrar la consulta
                LastNameRecep = request.LastNameRecep, // Apellido del recepcionista para filtrar la consulta
                IsDeleted = request.IsDeleted // Indicador de eliminación para filtrar la consulta
            };
            // Obtener la lista de recepcionistas según el filtro
            var Receptionists = await _repository.ListAsync(new PaginatedReceptionistSpecification(ResponseFilter));
            // Mapear la lista de recepcionistas a DTOs
            var ReceptionistDTO = _mapper.Map<IEnumerable<ReceptionistDTOs>>(Receptionists);
            // Devolver una respuesta paginada con los recepcionistas DTO
            return new PaginateResponse<IEnumerable<ReceptionistDTOs>>(ReceptionistDTO, request.PageNumber, request.PageSize, request.IsDeleted);
        }
    }
}