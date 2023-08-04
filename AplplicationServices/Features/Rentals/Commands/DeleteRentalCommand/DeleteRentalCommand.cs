using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand
{
    public class DeleteRentalCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, Response<long>>
    {
        private readonly IRepository<Rental> _repository;
        public DeleteRentalCommandHandler(IRepository<Rental> repository)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            // Obtener el cliente a eliminar por su Id
            var DRental = await _repository.GetByIdAsync(request.Id);
            if (DRental == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                // Marcar el cliente como eliminado
                DRental.IsDeleted = true;
                await _repository.UpdateAsync(DRental);
            }
            return new Response<long>(DRental.Id); // Devolver el Id del cliente eliminado en la respuesta
        }
    }
}