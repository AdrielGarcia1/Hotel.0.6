using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand
{
    public class DeleteRoomCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Response<long>>
    {
        private readonly IRepository<Room> _repository;
        public DeleteRoomCommandHandler(IRepository<Room> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var Room = await _repository.GetByIdAsync(request.Id);

            if (Room == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                await _repository.DeleteAsync(Room);
                return new Response<long>(Room.Id);
            }
        }
    }
}
