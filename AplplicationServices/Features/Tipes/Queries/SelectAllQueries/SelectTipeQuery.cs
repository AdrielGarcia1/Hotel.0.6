using ApplicationServices.DTOs;
using ApplicationServices.filters.Tipe;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.TipeS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Tipes.Queries.SelectAllQueries
{
    // Clase que representa la consulta para seleccionar todos los Tipos
    public class SelectTipeQuery : IRequest<PaginateResponse<IEnumerable<TipeDTOs>>>
    {
        public int PageNumber { get; set; } // Número de página
        public int PageSize { get; set; } // Tamaño de página
        public string? NameRoom { get; set; } // Nombre de la habitación
        public bool IsDeleted { get; set; } // Indicador de eliminado

        // Clase interna que maneja la ejecución de la consulta
        public class SelectTipeQueryHandler : IRequestHandler<SelectTipeQuery, PaginateResponse<IEnumerable<TipeDTOs>>>
        {
            private readonly IRepository<DomainClass.Entity.Types> _repository; // Repositorio de Tipos
            private readonly IMapper _mapper; // Objeto Mapper para mapear los Tipos a DTOs

            public SelectTipeQueryHandler(IRepository<DomainClass.Entity.Types> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            // Método que maneja la ejecución de la consulta
            async Task<PaginateResponse<IEnumerable<TipeDTOs>>> IRequestHandler<SelectTipeQuery, PaginateResponse<IEnumerable<TipeDTOs>>>.Handle(SelectTipeQuery request, CancellationToken cancellationToken)
            {
                // Crear el filtro de respuesta
                TipeResponseFilter ResponseFilter = new TipeResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameRoom = request.NameRoom,
                    IsDeleted = request.IsDeleted
                };
                // Obtener los Tipos de la base de datos utilizando la especificación paginada
                var Tipe = await _repository.ListAsync(new PaginatedTipeSpecification(ResponseFilter));

                // Mapear los Tipos a DTOs
                var TipeDTO = _mapper.Map<IEnumerable<TipeDTOs>>(Tipe);

                // Devolver la respuesta paginada de los DTOs de Tipos
                return new PaginateResponse<IEnumerable<TipeDTOs>>(TipeDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}