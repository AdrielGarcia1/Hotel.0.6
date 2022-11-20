using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Queries.SelectByQuery
{
    public class SelectReceptionistByQuery : IRequest<Response<ReceptionistDTOs>>
    {
        public long Id { get; set; }
    }
    public class SelectReceptionistByQueryHandler : IRequestHandler<SelectReceptionistByQuery, Response<ReceptionistDTOs>>
    {
        private readonly IRepository<Receptionist> _repository;
        private readonly IMapper _mapper;
        public SelectReceptionistByQueryHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<ReceptionistDTOs>> IRequestHandler<SelectReceptionistByQuery, Response<ReceptionistDTOs>>.Handle(SelectReceptionistByQuery request, CancellationToken cancellationToken)
        {
            var Receptionist = await _repository.GetByIdAsync(request.Id);
            if (Receptionist == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<ReceptionistDTOs>(Receptionist);
                return new Response<ReceptionistDTOs>(dto);
            }
        }

    }
}
