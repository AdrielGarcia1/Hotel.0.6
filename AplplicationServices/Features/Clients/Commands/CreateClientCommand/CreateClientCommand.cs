using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Commands.CreateClientCommand
{
    public class CreateClientCommand : IRequest<Response<long>>
    {
        public string NameClient { get; set; }
        public string LastNameClient { get; set; }
        public string CDirection { get; set; }
        public string Email { get; set; }
        public string TelephonoClient { get; set; }
    }
    public class CreateClientCommandHandler : IRequestHandler<CreateClientCommand, Response<long>>
    {
        private readonly IRepository<Client> _repository;
        private readonly IMapper _mapper;

        public CreateClientCommandHandler(IRepository<Client> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateClientCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<Client>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
