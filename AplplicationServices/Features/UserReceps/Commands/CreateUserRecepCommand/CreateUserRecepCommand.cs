using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand
{
    // Clase que representa el comando para crear un nuevo Usuario de Recepción
    public class CreateUserRecepCommand : IRequest<Response<long>>
    {
        public string NameUser { get; set; } // Nombre del usuario
        public string Password { get; set; } // Contraseña del usuario
        public string EmailRecep { get; set; } // Email de recepción del usuario
    }
    // Clase que maneja la ejecución del comando
    public class CreateUserRecepCommandHandler : IRequestHandler<CreateUserRecepCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository; // Repositorio de Usuarios de Recepción
        private readonly IMapper _mapper; // Objeto Mapper para mapear el comando a una entidad

        public CreateUserRecepCommandHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método que maneja la ejecución del comando
        public async Task<Response<long>> Handle(CreateUserRecepCommand request, CancellationToken cancellationToken)
        {
            // Encriptar la contraseña (código comentado)
            // request.Password = request.Password.Encriptar();

            // Mapear el comando a una entidad UserRecep
            var newRegister = _mapper.Map<DomainClass.Entity.UserRecep>(request);

            // Agregar la nueva entidad al repositorio
            var data = await _repository.AddAsync(newRegister);

            // Devolver una instancia de Response con el Id del nuevo registro
            return new Response<long>(data.Id);
        }
    }
}