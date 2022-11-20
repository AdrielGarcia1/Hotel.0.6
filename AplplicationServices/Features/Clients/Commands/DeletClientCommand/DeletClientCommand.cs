using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Commands.DeletClientCommand
{
    public class DeletClientCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class DeletClientCommandHandler : IRequestHandler<DeletClientCommand, Response<long>>
    {
        private readonly IRepository<Client> _repository;
        public DeletClientCommandHandler(IRepository<Client> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeletClientCommand request, CancellationToken cancellationToken)
        {
            var DClient = await _repository.GetByIdAsync(request.Id);

            if (DClient == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                DClient.IsDeleted = true;
                await _repository.UpdateAsync(DClient);
            }
            return new Response<long>(DClient.Id);
        }
    }
}
