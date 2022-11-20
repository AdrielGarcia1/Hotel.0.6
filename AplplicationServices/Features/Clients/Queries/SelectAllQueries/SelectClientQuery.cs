using ApplicationServices.DTOs;
using ApplicationServices.filters.ClientsF;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.CLientS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Clients.Queries.SelectAllQueries
{
    public class SelectClientQuery : IRequest<PaginateResponse<IEnumerable<ClientDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }//Ver
        public string? NameClient { get; set; }
        public string? LastNameClient { get; set; }
        public bool IsDeleted { get; set; }

        public class SelectUserQueryHandler : IRequestHandler<SelectClientQuery, PaginateResponse<IEnumerable<ClientDTOs>>>
        {
            private readonly IRepository<Client> _repository;
            private readonly IMapper _mapper;

            public SelectUserQueryHandler(IRepository<Client> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<ClientDTOs>>> Handle(SelectClientQuery request, CancellationToken cancellationToken)
            {
                ClientResponseFilter ResponseFilter = new ClientResponseFilter(){PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameClient = request.NameClient,
                    LastNameClient = request.LastNameClient,
                    IsDeleted = request.IsDeleted
                };

                var Clients = await _repository.ListAsync(new PaginatedCLientSpecification(ResponseFilter));
                var ClientDTOs = _mapper.Map<IEnumerable<ClientDTOs>>(Clients);
                return new PaginateResponse<IEnumerable<ClientDTOs>>(ClientDTOs, request.PageNumber, request.PageSize,request.IsDeleted);
            }
        }
    }
}
