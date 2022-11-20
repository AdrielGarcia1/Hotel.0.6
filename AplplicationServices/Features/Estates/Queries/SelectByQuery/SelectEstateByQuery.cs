using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Estates.Queries.SelectByQuery
{
    public class SelectEstateByQuery : IRequest<Response<EstateDTOs>>
    {
        public long Id { get; set; }
        public bool IsDeleted { get; set; }

    }
    public class SelectEstateByQueryHandler : IRequestHandler<SelectEstateByQuery, Response<EstateDTOs>>
    {
        private readonly IRepository<Estate> _repository;
        private readonly IMapper _mapper;
        public SelectEstateByQueryHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<EstateDTOs>> IRequestHandler<SelectEstateByQuery, Response<EstateDTOs>>.Handle(SelectEstateByQuery request, CancellationToken cancellationToken)
        {
            var Estate = await _repository.GetByIdAsync(request.Id);
            if (Estate == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<EstateDTOs>(Estate);
                return new Response<EstateDTOs>(dto);

            }
        }

    }
}
