using ApplicationServices.DTOs;
using ApplicationServices.filters.Room;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.RoomS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rooms.Queries.SelectAllQueries
{
    public class SelectRoomQuery : IRequest<PaginateResponse<IEnumerable<RoomDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NumberRoom { get; set; }
        public string? Cost { get; set; }
        public bool IsDeleted { get; set; }
        public class SelectRoomQueryHHandler : IRequestHandler<SelectRoomQuery, PaginateResponse<IEnumerable<RoomDTOs>>>
        {
            private readonly IRepository<Room> _repository;
            private readonly IMapper _mapper;

            public SelectRoomQueryHHandler (IRepository<Room> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<RoomDTOs>>> Handle(SelectRoomQuery request, CancellationToken cancellationToken)
            {
                RoomResponseFilter ResponseFilter = new RoomResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NumberRoom = request.NumberRoom,
                    Cost = request.Cost,
                    IsDeleted = request.IsDeleted
                };

                var Rooms = await _repository.ListAsync(new PaginatedRoomSpecification(ResponseFilter));
                var RoomDTO = _mapper.Map<IEnumerable<RoomDTOs>>(Rooms);
                return new PaginateResponse<IEnumerable<RoomDTOs>>(RoomDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }

}
