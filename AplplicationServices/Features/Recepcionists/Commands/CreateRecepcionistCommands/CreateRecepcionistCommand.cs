using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Commands.CreateRecepcionistCommands
{
    // Comando para crear un nuevo Receptionist
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

        // Método para manejar el comando y crear un nuevo Receptionist
        public async Task<Response<long>> Handle(CreateRecepcionistCommand request, CancellationToken cancellationToken)
        {
            // Se mapea el objeto CreateRecepcionistCommand a la entidad Receptionist
            var newRegister = _mapper.Map<Receptionist>(request);

            // Se agrega la entidad Receptionist a través del repositorio
            var data = await _repository.AddAsync(newRegister);

            // Se devuelve una respuesta que contiene el ID del Receptionist creado
            return new Response<long>(data.Id);
        }
    }
}