using ApplicationServices.DTOs;
using ApplicationServices.filters.Receptionist;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.ReceptionistS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Queries.SelectAllQueries
{
    public class SelectReceptionistQuery : IRequest<PaginateResponse<IEnumerable<ReceptionistDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }//Ver
        public string? NameRecep { get; set; }
        public string? LastNameRecep { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class SelectReceptionistQueryHandler : IRequestHandler<SelectReceptionistQuery, PaginateResponse<IEnumerable<ReceptionistDTOs>>>
    {
        private readonly IRepository<Receptionist> _repository;
        private readonly IMapper _mapper;

        public SelectReceptionistQueryHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<PaginateResponse<IEnumerable<ReceptionistDTOs>>> Handle(SelectReceptionistQuery request, CancellationToken cancellationToken)
        {
            ReceptionistResponseFilter ResponseFilter = new ReceptionistResponseFilter()
            {
                PageSize = request.PageSize,
                PageNumber = request.PageNumber,
                NameRecep = request.NameRecep,
                LastNameRecep = request.LastNameRecep,
                 IsDeleted = request.IsDeleted
            };

            var Receptionists = await _repository.ListAsync(new PaginatedReceptionistSpecification(ResponseFilter));
            var ReceptionistDTO = _mapper.Map<IEnumerable<ReceptionistDTOs>>(Receptionists);
            return new PaginateResponse<IEnumerable<ReceptionistDTOs>>(ReceptionistDTO, request.PageNumber, request.PageSize,request.IsDeleted);
        }
    }
}
