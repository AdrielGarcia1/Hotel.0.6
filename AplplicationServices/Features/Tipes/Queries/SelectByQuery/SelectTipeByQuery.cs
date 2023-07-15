using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Tipes.Queries.SelectByQuery
{
    // Clase que representa la consulta para seleccionar un Tipo por su Id
    public class SelectTipeByQuery : IRequest<Response<TipeDTOs>>
    {
        public long Id { get; set; } // Id del Tipo a seleccionar
    }
    // Clase que maneja la ejecución de la consulta
    public class SelectTipeByQueryHandler : IRequestHandler<SelectTipeByQuery, Response<TipeDTOs>>
    {
        private readonly IRepository<Types> _repository; // Repositorio de Tipos
        private readonly IMapper _mapper; // Objeto Mapper para mapear el Tipo a un DTO

        public SelectTipeByQueryHandler(IRepository<Types> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método que maneja la ejecución de la consulta
        async Task<Response<TipeDTOs>> IRequestHandler<SelectTipeByQuery, Response<TipeDTOs>>.Handle(SelectTipeByQuery request, CancellationToken cancellationToken)
        {
            // Obtener el Tipo por su Id desde el repositorio
            var Tipe = await _repository.GetByIdAsync(request.Id);

            // Verificar si el Tipo existe en la base de datos
            if (Tipe == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Mapear el Tipo a un DTO
                var dto = _mapper.Map<TipeDTOs>(Tipe);
                return new Response<TipeDTOs>(dto);
            }
        }
    }
}