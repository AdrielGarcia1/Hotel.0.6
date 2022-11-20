using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rentals.Commands.DeleteRentalCommand
{
    public class DeleteRentalCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
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
            var Rental = await _repository.GetByIdAsync(request.Id);

            if (Rental == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                await _repository.DeleteAsync(Rental);
                return new Response<long>(Rental.Id);
            }
            
        }
    }
}
