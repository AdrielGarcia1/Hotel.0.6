using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System.Net.Sockets;

namespace ApplicationServices.Features.UserReceps.Commands.DeleteUserRecepCommand
{
    // Clase que representa el comando para eliminar un Usuario de Recepción
    public class DeleteUserRecepCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // Id del usuario a eliminar
        public bool IsDeleted { get; set; }
    }
    // Clase que maneja la ejecución del comando
    public class DeleteUserRecepCommandHandler : IRequestHandler<DeleteUserRecepCommand, Response<long>>
    {
        private readonly IRepository<UserRecep> _repository; // Repositorio de Usuarios de Recepción

        public DeleteUserRecepCommandHandler(IRepository<UserRecep> repository)
        {
            _repository = repository;
        }

        // Método que maneja la ejecución del comando
        public async Task<Response<long>> Handle(DeleteUserRecepCommand request, CancellationToken cancellationToken)
        {
            // Obtener el Usuario de Recepción a eliminar
            var UserRecep = await _repository.GetByIdAsync(request.Id);

            // Verificar si el Usuario de Recepción existe
            if (UserRecep == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Eliminar el Usuario de Recepción
                UserRecep.IsDeleted = true;
                await _repository.UpdateAsync(UserRecep);
            }
            // Devolver una instancia de Response con el Id del registro eliminado
            return new Response<long>(UserRecep.Id);
        }
    }
}