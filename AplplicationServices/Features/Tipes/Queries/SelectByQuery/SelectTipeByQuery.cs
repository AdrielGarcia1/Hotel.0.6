using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Tipes.Queries.SelectByQuery
{
    public class SelectTipeByQuery : IRequest<Response<TipeDTOs>>
    {
        public long Id { get; set; }
    }
    public class SelectTipeByQueryHandler : IRequestHandler<SelectTipeByQuery, Response<TipeDTOs>>
    {
        private readonly IRepository<Types> _repository;
        private readonly IMapper _mapper;

        public SelectTipeByQueryHandler(IRepository<Types> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<Response<TipeDTOs>> IRequestHandler<SelectTipeByQuery, Response<TipeDTOs>>.Handle(SelectTipeByQuery request, CancellationToken cancellationToken)
        {
            var Tipe = await _repository.GetByIdAsync(request.Id);
            if (Tipe == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<TipeDTOs>(Tipe);
                return new Response<TipeDTOs>(dto);

            }
        }
    }
}
