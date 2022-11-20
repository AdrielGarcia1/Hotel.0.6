using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Recepcionists.Commands.DeleteReceptionistCommand
{
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

        public async Task<Response<long>> Handle(DeleteReceptionistCommand request, CancellationToken cancellationToken)
        {
            var Receptionist = await _repository.GetByIdAsync(request.Id);

            if (Receptionist == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                await _repository.DeleteAsync(Receptionist);
                return new Response<long>(Receptionist.Id);
            }
        }
    }
}
