using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand
{
    // Comando para eliminar un Receptionist
    public class DeleteReceptionistCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }

    public class DeleteReceptionistCommandHandler : IRequestHandler<DeleteReceptionistCommand, Response<long>>
    {
        private readonly IRepository<Receptionist> _repository;

        public DeleteReceptionistCommandHandler(IRepository<Receptionist> repository)
        {
            _repository = repository;
        }

        // Método que maneja la lógica de negocio para eliminar un Receptionist
        public async Task<Response<long>> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            // Obtener el Receptionist por su Id
            var Receptionist = await _repository.GetByIdAsync(request.Id);

            // Verificar si el Receptionist existe
            if (Receptionist == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Eliminar el Receptionist
                await _repository.DeleteAsync(Receptionist);
                return new Response<long>(Receptionist.Id);
            }
        }
    }
}