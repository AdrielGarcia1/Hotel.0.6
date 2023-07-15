using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Estates.Commands.DeletEstateCommand
{
    public class DeletStateCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeletStateCommandHandler : IRequestHandler<DeletStateCommand, Response<long>>
    {
        private readonly IRepository<Estate> _repository;

        public DeletStateCommandHandler(IRepository<Estate> repository)
        {
            _repository = repository;
        }
        public async Task<Response<long>> Handle(DeletStateCommand request, CancellationToken cancellationToken)
        {
            var Estate = await _repository.GetByIdAsync(request.Id);
            if (Estate == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                Estate.IsDeleted = false;
                await _repository.DeleteAsync(Estate);
                return new Response<long>(Estate.Id);
            }
        }
    }
}