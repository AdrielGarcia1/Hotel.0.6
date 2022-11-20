using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using MediatR;
using DomainClass.Entity;
using AutoMapper;

namespace ApplicationServices.Features.Estates.Commands.CreateEstateCommand
{
    public class CreateEstateCommand : IRequest<Response<long>>
    {
        public string NameEstate { get; set; }
    }
    public class CreateEstateCommandHandler : IRequestHandler<CreateEstateCommand, Response<long>>
    {
        private readonly IRepository<Estate> _repository;
        private readonly IMapper _mapper;
        public CreateEstateCommandHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Estate>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<long>(data.Id);
        }
    }
}
