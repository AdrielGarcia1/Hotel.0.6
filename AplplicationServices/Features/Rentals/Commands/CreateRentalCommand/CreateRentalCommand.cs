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
    public class CreateRentalCommand : IRequest<Response<long>>
    {
        public DateTime DateAndhoursGet { get; set; }
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DateAndhoursSet { get; set; }
        public string TotalCost { get; set; }
        public string Observation { get; set; }
        public long RoomId { get; set; }
        public long ClientId { get; set; }
        public long ReceptionistId { get; set; }
        public long EstateId { get; set; }
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
            var newRegister = _mapper.Map<Rental>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<long>(data.Id);
        }
    }
}
