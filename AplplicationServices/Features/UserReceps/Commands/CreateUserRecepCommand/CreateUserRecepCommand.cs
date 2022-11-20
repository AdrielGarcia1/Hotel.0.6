using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.UserReceps.Commands.CreateUserRecepCommand
{
    public class CreateUserRecepCommand : IRequest<Response<long>>
    {
        public string NameUser { get; set; }
        public string Password { get; set; }
        public string EmailRecep { get; set; }
    }
    public class CreateUserRecepCommandHandler : IRequestHandler<CreateUserRecepCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository;
        private readonly IMapper _mapper;

        public CreateUserRecepCommandHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Response<long>> Handle(CreateUserRecepCommand request, CancellationToken cancellationToken)
        {
            //request.Password = request.Password.Encriptar();
            var newRegister = _mapper.Map<DomainClass.Entity.UserRecep>(request);
            var data = await _repository.AddAsync(newRegister);

            return new Response<long>(data.Id);
        }
    }
}
