using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Commands.CreateClientCommand
{
    // Comando para crear un cliente
    // Implementa IRequest<Response<long>> para obtener la respuesta del comando

    public class CreateClientCommand : IRequest<Response<long>>
    {
        public string NameClient { get; set; } // Nombre del cliente
        public string LastNameClient { get; set; } // Apellido del cliente
        public string CDirection { get; set; } // Dirección del cliente
        public string Email { get; set; } // Email del cliente
        public string TelephonoClient { get; set; } // Teléfono del cliente
    }

    // Manejador del comando CreateClientCommand
    // Implementa IRequestHandler<CreateClientCommand, Response<long>> para manejar el comando y generar la respuesta

    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<long>>
    {
        private readonly IRepository<Client> _repository; // Repositorio para acceder a los datos de los clientes
        private readonly IMapper _mapper; // Mapper para mapear el objeto de comando al objeto de entidad

        public CreateClientCommandHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar(); // Se podría realizar alguna operación adicional en los datos del cliente antes de almacenarlos
            var newRegister = _mapper.Map<Client>(request); // Mapeo del objeto de comando al objeto de entidad Client
            var data = await _repository.AddAsync(newRegister); // Almacenar el nuevo cliente en el repositorio

            return new Response<long>(data.Id); // Devolver la respuesta exitosa con el ID del cliente creado
        }
    }
}