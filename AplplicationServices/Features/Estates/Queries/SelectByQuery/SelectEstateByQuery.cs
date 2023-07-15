using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Estates.Queries.SelectByQuery
{
    // Consulta para seleccionar un Estate por su ID
    public class SelectEstateByQuery : IRequest<Response<EstateDTOs>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class SelectEstateByQueryHandler : IRequestHandler<SelectEstateByQuery, Response<EstateDTOs>>
    {
        private readonly IRepository<Estate> _repository;
        private readonly IMapper _mapper;
        public SelectEstateByQueryHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método para manejar la consulta y devolver una respuesta con el DTO de Estate
        async Task<Response<EstateDTOs>> IRequestHandler<SelectEstateByQuery, Response<EstateDTOs>>.Handle(SelectEstateByQuery request, CancellationToken cancellationToken)
        {
            // Se obtiene la entidad de Estate según el ID proporcionado
            var Estate = await _repository.GetByIdAsync(request.Id);
            if (Estate == null)
            {
                // Si no se encuentra el registro con el ID proporcionado, se lanza una excepción
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Se mapea la entidad de Estate a un DTO de Estate
                var dto = _mapper.Map<EstateDTOs>(Estate);
                // Se devuelve la respuesta que contiene el DTO de Estate
                return new Response<EstateDTOs>(dto);
            }
        }

    }
}