using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rooms.Commands.CreateRoomCommand
{
    public class CreateRoomCommand : IRequest<Response<long>>
    {
        public string NumberRoom { get; set; }
        public string Cost { get; set; }
        public string Description { get; set; }
        public long TypesId { get; set; }
    }
    public class CreateRoomCommandHandler : IRequestHandler<CreateRoomCommand, Response<long>>
    {
        private readonly IRepository<Room> _repository;
        private readonly IMapper _mapper;
        public CreateRoomCommandHandler(IRepository<Room> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<Response<long>> Handle(CreateRoomCommand request, CancellationToken cancellationToken)
        {
            var newRegister = _mapper.Map<Room>(request);
            var data = await _repository.AddAsync(newRegister);
            return new Response<long>(data.Id);
        }
    }
}
