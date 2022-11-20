using ApplicationServices.DTOs;
using ApplicationServices.filters.UserRecep;
using ApplicationServices.Interfaces;
using ApplicationServices.Specification.UserRecepS;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.UserReceps.Queries.SelectAllQueries
{
    public class SelectUserRecepQuery : IRequest<PaginateResponse<IEnumerable<UserRecepDTOs>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string? NameUser { get; set; }
        public bool IsDeleted { get; set; }
        public class SelectUserRecepByQueryHandler : IRequestHandler<SelectUserRecepQuery, PaginateResponse<IEnumerable<UserRecepDTOs>>>
        {
            private readonly IRepository<DomainClass.Entity.UserRecep> _repository;
            private readonly IMapper _mapper;

            public SelectUserRecepByQueryHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            public async Task<PaginateResponse<IEnumerable<UserRecepDTOs>>> Handle(SelectUserRecepQuery request, CancellationToken cancellationToken)
            {
                UserRecepResponseFilter ResponseFilter = new UserRecepResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameUser = request.NameUser,
                    IsDeleted = request.IsDeleted,
                };

                var UserRecep = await _repository.ListAsync(new PaginatedUserRecepSpecification(ResponseFilter));
                var UserRecepDTO = _mapper.Map<IEnumerable<UserRecepDTOs>>(UserRecep);
                return new PaginateResponse<IEnumerable<UserRecepDTOs>>(UserRecepDTO, request.PageNumber, request.PageSize,request.IsDeleted);
            }
        }
    }
}
