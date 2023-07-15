using ApplicationServices.DTOs;
using ApplicationServices.filters.Rental;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.RentalS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Rentals.Queries.SelectAllQueries
{
    public class SelectRentalQuery : IRequest<PaginateResponse<IEnumerable<RentalDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? TotalCost { get; set; }
        public bool IsDeleted { get; set; }
        public class SelectRentalQueryHandler : IRequestHandler<SelectRentalQuery, PaginateResponse<IEnumerable<RentalDTOs>>>
        {
            private readonly IRepository<Rental> _repository;
            private readonly IMapper _mapper;

            public SelectRentalQueryHandler(IRepository<Rental> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<RentalDTOs>>> Handle(SelectRentalQuery request, CancellationToken cancellationToken)
            {
                RentalResponseFilter ResponseFilter = new RentalResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    TotalCost = request.TotalCost,
                    IsDeleted = request.IsDeleted
                };
                var Rentals = await _repository.ListAsync(new PaginatedRentalSpecification(ResponseFilter));
                var RentalDTO = _mapper.Map<IEnumerable<RentalDTOs>>(Rentals);
                return new PaginateResponse<IEnumerable<RentalDTOs>>(RentalDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}