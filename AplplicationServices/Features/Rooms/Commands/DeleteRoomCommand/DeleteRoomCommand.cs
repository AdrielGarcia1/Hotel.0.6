using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
namespace ApplicationServices.Features.Rooms.Commands.DeleteRoomCommand
{
    // Comando para eliminar una habitación
    public class DeleteRoomCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // Id de la habitación a eliminar
        public bool IsDeleted { get; set; }
    }
    // Manejador del comando para eliminar una habitación
    public class DeleteRoomCommandHandler : IRequestHandler<DeleteRoomCommand, Response<long>>
    {
        private readonly IRepository<Room> _repository;

        public DeleteRoomCommandHandler(IRepository<Room> repository)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(DeleteRoomCommand request, CancellationToken cancellationToken)
        {
            var Room = await _repository.GetByIdAsync(request.Id); // Obtener la habitación por su Id

            if (Room == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}"); // Si no se encuentra la habitación, lanzar una excepción
            }
            else
            {
                // Marcar la habitación como eliminado
                Room.IsDeleted = true;
                await _repository.UpdateAsync(Room);

            }
            return new Response<long>(Room.Id); // Devolver el Id de la habitación eliminada en la respuesta
        }
    }
}