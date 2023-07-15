using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Rooms.Commands.CreateRoomCommand
{
    // Comando para crear una habitación
    public class CreateRoomCommand : IRequest<Response<long>>
    {
        public string NumberRoom { get; set; }     // Número de habitación
        public string Cost { get; set; }           // Costo de la habitación
        public string Description { get; set; }    // Descripción de la habitación
        public long TypesId { get; set; }          // ID del tipo de habitación
    }
    // Manejador del comando para crear una habitación
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Response<long>>
    {
        private readonly IRepository<Room> _repository;   // Repositorio de habitaciones
        private readonly IMapper _mapper;                 // Mapeador

        public CreateRoomCommandHandler(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método para manejar el comando de creación de habitación
        public async Task<Response<long>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            // Mapear los datos del comando a un objeto Room
            var newRegister = _mapper.Map<Room>(request);

            // Agregar la nueva habitación al repositorio
            var data = await _repository.AddAsync(newRegister);

            // Devolver una respuesta con el ID de la habitación creada
            return new Response<long>(data.Id);
        }
    }
}