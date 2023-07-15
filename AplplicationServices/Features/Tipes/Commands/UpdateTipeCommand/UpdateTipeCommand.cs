using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Tipes.Commands.UpdateTipeCommand
{
    public class UpdateTipeCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string? NameRoom { get; set; }
        public string? DescriptionRoom { get; set; }
    }
    public class UpdateTipeCommandHandler : IRequestHandler<UpdateTipeCommand, Response<long>>
    {
        private readonly IRepository<Types> _repository;
        private readonly IMapper _mapper;

        public UpdateTipeCommandHandler(IRepository<Types> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(UpdateTipeCommand request, CancellationToken cancellationToken)
        {
            // Obtener el tipo por el Id
            var Tipe = await _repository.GetByIdAsync(request.Id);

            if (Tipe == null)
            {
                // Si el tipo no existe, lanzar una excepción
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Actualizar las propiedades del tipo con los valores del comando
                Tipe.NameRoom = request.NameRoom;
                Tipe.DescriptionRoom = request.DescriptionRoom;

                // Actualizar el tipo en el repositorio
                await _repository.UpdateAsync(Tipe);

                // Devolver una respuesta con el Id del tipo actualizado
                return new Response<long>(Tipe.Id);
            }
        }
    }
}