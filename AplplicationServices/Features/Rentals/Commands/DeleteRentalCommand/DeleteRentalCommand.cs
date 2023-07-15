using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand
{
    // Comando para eliminar un alquiler
    public class DeleteRentalCommand : IRequest<Response<long>>
    {
        public long Id { get; set; } // ID del alquiler a eliminar
    }
    // Manejador del comando DeleteRentalCommand
    public class DeleteRentalCommandHandler : IRequestHandler<DeleteRentalCommand, Response<long>>
    {
        private readonly IRepository<Rental> _repository; // Repositorio para acceder a los datos de los alquileres
        public DeleteRentalCommandHandler(IRepository<Rental> repository)
        {
            _repository = repository;
        }
        // Método para manejar el comando y realizar la eliminación del alquiler
        public async Task<Response<long>> Handle(DeleteRentalCommand request, CancellationToken cancellationToken)
        {
            var Rental = await _repository.GetByIdAsync(request.Id); // Obtener el alquiler por su ID

            if (Rental == null) // Si no se encuentra el alquiler
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}"); // Lanzar excepción
            }
            else // Si se encuentra el alquiler
            {
                await _repository.DeleteAsync(Rental); // Eliminar el alquiler utilizando el repositorio
                return new Response<long>(Rental.Id); // Devolver una respuesta exitosa con el ID del alquiler eliminado
            }
        }
    }
}