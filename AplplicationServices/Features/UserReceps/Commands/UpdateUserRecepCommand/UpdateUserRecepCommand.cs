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
namespace ApplicationServices.Features.UserReceps.Commands.UpdateUserRecepCommand
{
    // Clase que representa el comando para actualizar un Usuario de Recepción
    public class UpdateUserRecepCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // Id del usuario a actualizar
        public string? NameUser { get; set; } // Nuevo nombre de usuario
        public string? Password { get; set; } // Nueva contraseña
        public string? EmailRecep { get; set; } // Nuevo correo electrónico
    }
    // Clase que maneja la ejecución del comando
    public class UpdateUserRecepCommandHandler : IRequestHandler<UpdateUserRecepCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository; // Repositorio de Usuarios de Recepción

        public UpdateUserRecepCommandHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
        }

        // Método que maneja la ejecución del comando
        public async Task<Response<long>> Handle(UpdateUserRecepCommand request, CancellationToken cancellationToken)
        {
            // Obtener el Usuario de Recepción a actualizar
            var UserRecep = await _repository.GetByIdAsync(request.Id);

            // Verificar si el Usuario de Recepción existe
            if (UserRecep == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Actualizar los campos del Usuario de Recepción
                UserRecep.NameUser = request.NameUser;
                UserRecep.Password = request.Password;
                UserRecep.EmailRecep = request.EmailRecep;

                // Actualizar el Usuario de Recepción en el repositorio
                await _repository.UpdateAsync(UserRecep);

                // Devolver una instancia de Response con el Id del registro actualizado
                return new Response<long>(UserRecep.Id);
            }
        }
    }
}