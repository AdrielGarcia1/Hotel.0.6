using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Rooms.Queries.SelectByQuery
{
    // Clase de consulta para seleccionar una habitación por su identificador
    public class SelectRoomByQuery : IRequest<Response<RoomDTOs>>
    {
        public long Id { get; set; }
    }
    // Controlador de la consulta SelectRoomByQuery
    public class SelectRoomByQueryHandler : IRequestHandler<SelectRoomByQuery, Response<RoomDTOs>>
    {
        private readonly IRepository<Room> _repository;
        private readonly IMapper _mapper;

        public SelectRoomByQueryHandler(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método para manejar la consulta SelectRoomByQuery
        async Task<Response<RoomDTOs>> IRequestHandler<SelectRoomByQuery, Response<RoomDTOs>>.Handle(SelectRoomByQuery request, CancellationToken cancellationToken)
        {
            // Obtener la habitación del repositorio por su identificador
            var Room = await _repository.GetByIdAsync(request.Id);

            if (Room == null)
            {
                // Si no se encuentra la habitación, lanzar una excepción
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Mapear la habitación a un objeto RoomDTOs utilizando el mapeador
                var dto = _mapper.Map<RoomDTOs>(Room);

                // Devolver la habitación mapeada como parte de la respuesta
                return new Response<RoomDTOs>(dto);
            }
        }
    }
}
