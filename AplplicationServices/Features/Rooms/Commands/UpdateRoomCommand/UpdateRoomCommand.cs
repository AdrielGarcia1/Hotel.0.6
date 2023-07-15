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
                Room.NumberRoom = request.NumberRoom; // Actualiza el campo NumberRoom con el valor del comando
                Room.Cost = request.Cost; // Actualiza el campo Cost con el valor del comando
                Room.Description = request.Description; // Actualiza el campo Description con el valor del comando
                Room.TypesId = request.TypesId; // Actualiza el campo TypesId con el valor del comando

                await _repository.UpdateAsync(Room); // Actualiza la entidad Room en el repositorio
            }

            return new Response<long>(Room.Id); // Devuelve una respuesta con el Id de la habitación actualizada
        }
    }
}

