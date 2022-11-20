using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Tipes.Commands.CreateTipeCommand
{
    public class CreateTipeCommand : IRequest<Response<long>>
    {
        public string NameRoom { get; set; }
        public string DescriptionRoom { get; set; }
    }
    public class CreateTipeCommandHandler : IRequestHandler<CreateTipeCommand, Response<long>>
    {
        private readonly IRepository<Types> _repository;
        private readonly IMapper _mapper;
        public CreateTipeCommandHandler(IRepository<Types> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateTipeCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Types>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<long>(data.Id);
        }
    }
}
