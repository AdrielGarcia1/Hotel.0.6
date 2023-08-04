using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System.Net.Sockets;

namespace ApplicationServices.Features.Tipes.Commands.DeleteTipeCommand
{
    // Comando para eliminar un Tipe
    public class DeleteTipeCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    // Manejador del comando DeleteTipeCommand
    public class DeleteTipeCommandHandler : IRequestHandler<DeleteTipeCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.Types> _repository;

        public DeleteTipeCommandHandler(IRepository<DomainClass.Entity.Types> repository)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(DeleteTipeCommand request, CancellationToken cancellationToken)
        {
            // Obtener el Tipe a eliminar por su Id
            var Tipe = await _repository.GetByIdAsync(request.Id);

            if (Tipe == null)
            {
                // Si el Tipe no existe, lanzar una excepción
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Si el Tipe existe, eliminarlo
                Tipe.IsDeleted = true;
                await _repository.UpdateAsync(Tipe);
                
            }
            return new Response<long>(Tipe.Id);
        }
    }
}