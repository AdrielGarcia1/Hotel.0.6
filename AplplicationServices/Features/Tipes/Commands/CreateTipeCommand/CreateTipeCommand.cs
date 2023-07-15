using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Tipes.Commands.CreateTipeCommand
{
    // Clase de comando para crear un tipo de habitación
    public class CreateTipeCommand : IRequest<Response<long>>
    {
        public string NameRoom { get; set; }
        public string DescriptionRoom { get; set; }
    }
    // Controlador del comando CreateTipeCommand
    public class CreateTipeCommandHandler : IRequestHandler<CreateTipeCommand, Response<long>>
    {
        private readonly IRepository<Types> _repository;
        private readonly IMapper _mapper;

        public CreateTipeCommandHandler(IRepository<DomainClass.Entity.Types> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método para manejar el comando CreateTipeCommand
        public async Task<Response<long>> Handle(CreateTipeCommand request, CancellationToken cancellationToken)
        {
            // Mapear los datos del comando a un objeto Types utilizando el mapeador
            var newRegister = _mapper.Map<DomainClass.Entity.Types>(request);

            // Agregar el nuevo registro al repositorio
            var data = await _repository.AddAsync(newRegister);

            // Devolver la respuesta con el identificador del nuevo registro
            return new Response<long>(data.Id);
        }
    }
}