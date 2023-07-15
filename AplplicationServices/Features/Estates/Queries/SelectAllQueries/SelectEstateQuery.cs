using ApplicationServices.DTOs;
using ApplicationServices.filters.Estate;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.EstateS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Estates.Queries.SelectAllQueries
{
    public class SelectEstateQuery : IRequest<PaginateResponse<IEnumerable<EstateDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NameEstate { get; set; }
        public bool IsDeleted { get; set; }
        public class SelectEstateQueryHandler : IRequestHandler<SelectEstateQuery, PaginateResponse<IEnumerable<EstateDTOs>>>
        {
            private readonly IRepository<Estate> _repository;
            private readonly IMapper _mapper;
            public SelectEstateQueryHandler(IRepository<Estate> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<EstateDTOs>>> Handle(SelectEstateQuery request, CancellationToken cancellationToken)
            {
                // Se crea un filtro de respuesta para la consulta
                EstateResponseFilter ResponseFilter = new EstateResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameEstate = request.NameEstate,
                    IsDeleted = request.IsDeleted
                };
                // Se obtienen las entidades de Estate que cumplen con el filtro de respuesta
                var Estates = await _repository.ListAsync(new PaginatedStateSpecification(ResponseFilter));
                // Se mapean las entidades de Estate a DTOs de Estate
                var EstateDTO = _mapper.Map<IEnumerable<EstateDTOs>>(Estates);
                // Se devuelve la respuesta paginada que contiene los DTOs de Estate
                return new PaginateResponse<IEnumerable<EstateDTOs>>(EstateDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}