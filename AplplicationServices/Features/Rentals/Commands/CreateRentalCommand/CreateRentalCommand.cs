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
namespace ApplicationServices.Features.Rentals.Commands.CreateRentalCommand
{
    // Comando para crear un alquiler
    public class CreateRentalCommand : IRequest<Response<long>>
    {
        public DateTime DateAndhoursGet { get; set; } // Fecha y hora de inicio del alquiler
        public DateTime DateAndhoursSet { get; set; } // Fecha y hora de finalización del alquiler
        public string TotalCost { get; set; } // Costo total del alquiler
        public string Observation { get; set; } // Observaciones adicionales del alquiler
        public long RoomId { get; set; } // Id de la habitación alquilada
        public long ClientId { get; set; } // Id del cliente que realiza el alquiler
        public long ReceptionistId { get; set; } // Id del recepcionista que realiza el alquiler
        public long EstateId { get; set; } // Id del estado del alquiler
    }
    public class CreateRentalCommandHandler : IRequestHandler<CreateRentalCommand, Response<long>>
    {
        private readonly IRepository<Rental> _repository;
        private readonly IMapper _mapper;

        public CreateRentalCommandHandler(IRepository<Rental> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateRentalCommand request, CancellationToken cancellationToken)
        {
            // Mapear los datos del comando a una entidad Rental
            var newRegister = _mapper.Map<Rental>(request);

            // Agregar el nuevo alquiler a la base de datos
            var data = await _repository.AddAsync(newRegister);

            // Devolver una respuesta con el Id del nuevo alquiler
            return new Response<long>(data.Id);
        }
    }
}