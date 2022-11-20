using ApplicationServices.DTOs;
using ApplicationServices.filters.Tipe;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.TipeS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Tipes.Queries.SelectAllQueries
{
    public class SelectTipeQuery : IRequest<PaginateResponse<IEnumerable<TipeDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NameRoom { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectTipeQueryHandler : IRequestHandler<SelectTipeQuery, PaginateResponse<IEnumerable<TipeDTOs>>>
        {
            private readonly IRepository<DomainClass.Entity.Types> _repository;
            private readonly IMapper _mapper;
            public SelectTipeQueryHandler(IRepository<DomainClass.Entity.Types> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }

            async Task<PaginateResponse<IEnumerable<TipeDTOs>>> IRequestHandler<SelectTipeQuery, PaginateResponse<IEnumerable<TipeDTOs>>>.Handle(SelectTipeQuery request, CancellationToken cancellationToken)
            {
                TipeResponseFilter ResponseFilter = new TipeResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameRoom = request.NameRoom,
                    IsDeleted = request.IsDeleted
                };

                var Tipe = await _repository.ListAsync(new PaginatedTipeSpecification(ResponseFilter));
                var TipeDTO = _mapper.Map<IEnumerable<TipeDTOs>>(Tipe);
                return new PaginateResponse<IEnumerable<TipeDTOs>>(TipeDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}
