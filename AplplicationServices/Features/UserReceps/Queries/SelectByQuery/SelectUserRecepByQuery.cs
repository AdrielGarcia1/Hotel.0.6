using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.UserReceps.Queries.SelectByQuery
{
    public class SelectUserRecepByQuery : IRequest<Response<UserRecepDTOs>>
    {
        public long Id { get; set; }
    }
    public class SelectUserRecepByQueryHandler : IRequestHandler<SelectUserRecepByQuery, Response<UserRecepDTOs>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository;
        private readonly IMapper _mapper;

        public SelectUserRecepByQueryHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<Response<UserRecepDTOs>> IRequestHandler<SelectUserRecepByQuery, Response<UserRecepDTOs>>.Handle(SelectUserRecepByQuery request, CancellationToken cancellationToken)
        {
            var UserRecep = await _repository.GetByIdAsync(request.Id);
            if (UserRecep == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<UserRecepDTOs>(UserRecep);
                return new Response<UserRecepDTOs>(dto);

            }
        }
    }
}
