using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Commands.UpdateClientCommand
{
    public class UpdateClientCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string NameClient { get; set; }
        public string LastNameClient { get; set; }
        public string CDirection { get; set; }
        public string Email { get; set; }
        public string TelephonoClient { get; set; }
    }
        public class UpdateClientCommandHandler : IRequestHandler<UpdateClientCommand, Response<long>>
        {
            private readonly IRepository<Client> _repository;

            public UpdateClientCommandHandler(IRepository<Client> repository, IMapper mapper)
            {
                _repository = repository;
            }

          public async Task<Response<long>> Handle(UpdateClientCommand request, CancellationToken cancellationToken)
          {
            var Client = await _repository.GetByIdAsync(request.Id);

            if(Client==null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }else
            {
                Client.NameClient = request.NameClient;
                Client.LastNameClient = request.LastNameClient;
                Client.CDirection = request.CDirection;
                Client.Email = request.Email;
                Client.TelephonoClient = request.TelephonoClient;
                await _repository.UpdateAsync(Client);
            }
            return new Response<long>(Client.Id);
          }
        }
}
