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
        public long Id { get; set; }
        public DateTime DateAndhoursGet { get; set; }
        public DateTime DateAndhoursSet { get; set; }
        public string TotalCost { get; set; }
        public string Observation { get; set; }
        public long IdRoom { get; set; }
        public long IdClient { get; set; }
        public long ReceptionistId { get; set; }
        public long IdState { get; set; }
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
            var Rental = await _repository.GetByIdAsync(request.Id);

            if (Rental == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                Rental.DateAndhoursGet = request.DateAndhoursGet;
                Rental.DateAndhoursSet = request.DateAndhoursSet;
                Rental.TotalCost = request.TotalCost;
                Rental.Observation = request.Observation;
                Rental.RoomId = request.IdRoom;
                Rental.ClientId = request.IdClient;
                Rental.ReceptionistId = request.ReceptionistId;
                Rental.EstateId = request.IdState;
                await _repository.UpdateAsync(Rental);
                
            }
            return new Response<long>(Rental.Id);

        }
    }
}
