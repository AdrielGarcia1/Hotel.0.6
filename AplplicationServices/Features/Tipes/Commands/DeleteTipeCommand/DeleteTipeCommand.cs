using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Tipes.Commands.DeleteTipeCommand
{
    public class DeleteTipeCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeleteTipeCommandHandler : IRequestHandler<DeleteTipeCommand, Response<long>>
    {
        private readonly IRepository<Types> _repository;
        public DeleteTipeCommandHandler(IRepository<Types> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteTipeCommand request, CancellationToken cancellationToken)
        {
            var Tipe = await _repository.GetByIdAsync(request.Id);

            if (Tipe == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                await _repository.DeleteAsync(Tipe);
                return new Response<long>(Tipe.Id);
            }
        }
    }
}
