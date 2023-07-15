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
namespace ApplicationServices.Features.Rentals.Commands.UpdateRentalCommand
{
    public class UpdateRentalCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // ID del alquiler a actualizar
        public DateTime DateAndhoursGet { get; set; } // Fecha y hora de inicio del alquiler
        public DateTime DateAndhoursSet { get; set; } // Fecha y hora de fin del alquiler
        public string TotalCost { get; set; } // Costo total del alquiler
        public string Observation { get; set; } // Observación del alquiler
        public long IdRoom { get; set; } // ID de la habitación del alquiler
        public long IdClient { get; set; } // ID del cliente del alquiler
        public long ReceptionistId { get; set; } // ID del recepcionista del alquiler
        public long IdState { get; set; } // ID del estado del alquiler
    }
    public class UpdateRentalCommandHandler : IRequestHandler<UpdateRentalCommand, Response<long>>
    {
        private readonly IRepository<Rental> _repository;
        public UpdateRentalCommandHandler(IRepository<Rental> repository, IMapper mapper)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(UpdateRentalCommand request, CancellationToken cancellationToken)
        {
            var Rental = await _repository.GetByIdAsync(request.Id); // Obtener el alquiler existente por su ID
            if (Rental == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}"); // Lanzar excepción si no se encuentra el alquiler
            }
            else
            {
                // Actualizar las propiedades del alquiler con los valores proporcionados en el comando
                Rental.DateAndhoursGet = request.DateAndhoursGet;
                Rental.DateAndhoursSet = request.DateAndhoursSet;
                Rental.TotalCost = request.TotalCost;
                Rental.Observation = request.Observation;
                Rental.RoomId = request.IdRoom;
                Rental.ClientId = request.IdClient;
                Rental.ReceptionistId = request.ReceptionistId;
                Rental.EstateId = request.IdState;
                await _repository.UpdateAsync(Rental); // Actualizar el alquiler en el repositorio
            }
            return new Response<long>(Rental.Id); // Devolver el ID del alquiler actualizado en una respuesta
        }
    }
}