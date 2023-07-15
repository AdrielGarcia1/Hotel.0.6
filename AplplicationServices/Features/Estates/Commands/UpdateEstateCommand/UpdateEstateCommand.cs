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
namespace ApplicationServices.Features.Estates.Commands.UpdateEstateCommand
{
    // Comando para actualizar una entidad Estate
    public class UpdateEstateCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // Identificador de la entidad
        public string NameEstate { get; set; } // Nuevo nombre de la entidad
    }
    // Manejador del comando UpdateEstateCommand
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand, Response<long>>
    {
        private readonly IRepository<Estate> _repository;

        public UpdateEstateCommandHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
        }
        // Método para manejar el comando y realizar la actualización
        public async Task<Response<long>> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            // Obtener la entidad Estate por su Id
            var Estate = await _repository.GetByIdAsync(request.Id);

            if (Estate == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Actualizar el nombre de la entidad con el nuevo valor proporcionado
                Estate.NameEstate = request.NameEstate;

                // Actualizar la entidad en el repositorio
                await _repository.UpdateAsync(Estate);
            }
            // Devolver una respuesta exitosa con el Id de la entidad actualizada
            return new Response<long>(Estate.Id);
        }
    }
}