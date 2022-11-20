using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rooms.Queries.SelectByQuery
{
    public class SelectRoomByQuery : IRequest<Response<RoomDTOs>>
    {
        public long Id { get; set; }
    }
    public class SelectRoomByQueryHandler : IRequestHandler<SelectRoomByQuery, Response<RoomDTOs>>
    {
        private readonly IRepository<Room> _repository;
        private readonly IMapper _mapper;

        public SelectRoomByQueryHandler(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

         async Task<Response<RoomDTOs>> IRequestHandler<SelectRoomByQuery, Response<RoomDTOs>>.Handle(SelectRoomByQuery request, CancellationToken cancellationToken)
        {
            var Room = await _repository.GetByIdAsync(request.Id);
            if (Room == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<RoomDTOs>(Room);
                return new Response<RoomDTOs>(dto);

            }
        }
    }
}
