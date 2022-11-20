using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Commands.CreateRecepcionistCommands
{
    public class CreateRecepcionistCommand : IRequest<Response<long>>
    {
        public string NameRecep { get; set; }
        public string LastNameRecep { get; set; }
        public string RDirection { get; set; }
        public string EmailRecep { get; set; }
        public string DocumentRecep { get; set; }
        public string TelephoneRecep { get; set; }
        public string Estate { get; set; }
        public string Observation { get; set; }
        public long UserRecepId { get; set; }
    }
    public class CreateRecepcionistCommandHandler : IRequestHandler<CreateRecepcionistCommand, Response<long>>
    {
        private readonly IRepository<Receptionist> _repository;
        private readonly IMapper _mapper;
        public CreateRecepcionistCommandHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateRecepcionistCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Receptionist>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<long>(data.Id);
        }
    }
}
