using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Rooms.Commands.UpdateRoomCommand
{
    public class UpdateRoomCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string NumberRoom { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public long TypesId { get; set; }
    }
    public class UpdateRoomCommandHandler : IRequestHandler<UpdateRoomCommand, Response<long>>
    {
        private readonly IRepository<Room> _repository;
        public UpdateRoomCommandHandler(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(UpdateRoomCommand request, CancellationToken cancellationToken)
        {
            var Room = await _repository.GetByIdAsync(request.Id);

            if (Room == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                Room.NumberRoom = request.NumberRoom;
                Room.Cost = request.Cost;
                Room.Description = request.Description; 
                Room.TypesId = request.TypesId;

                await _repository.UpdateAsync(Room);
                
            }
           return new Response<long>(Room.Id);
        }
    }
}
