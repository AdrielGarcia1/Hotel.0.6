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
        // Constructor que recibe las dependencias necesarias para manejar la solicitud
        public CreateEstateCommandHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método para manejar la solicitud
        public async Task<Response<long>> Handle(CreateEstateCommand request, CancellationToken cancellationToken)
        {
            // Realizar el mapeo del objeto CreateEstateCommand a la entidad Estate utilizando el IMapper
            var newEstate = _mapper.Map<Estate>(request);

            // Agregar la nueva entidad al repositorio
            var data = await _repository.AddAsync(newEstate);
            // Devolver una respuesta que contiene el Id de la entidad creada
            return new Response<long>(data.Id);
        }
    }
}