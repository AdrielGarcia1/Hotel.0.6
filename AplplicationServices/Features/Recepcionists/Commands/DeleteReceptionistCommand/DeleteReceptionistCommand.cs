using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand
{
    public class DeleteReceptionistCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand, Response<long>>
    {
        private readonly IRepository<Receptionist> _repository;
        public DeleteReceptionistCommandHandler(IRepository<Receptionist> repository)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            // Obtener el cliente a eliminar por su Id
            var DReceptionist = await _repository.GetByIdAsync(request.Id);
            if (DReceptionist == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Marcar el cliente como eliminado
                DReceptionist.IsDeleted = true;
                await _repository.UpdateAsync(DReceptionist);
            }
            return new Response<long>(DReceptionist.Id); // Devolver el Id del cliente eliminado en la respuesta
        }
    }
}