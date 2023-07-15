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
    // Clase que representa la consulta para seleccionar todos los usuarios de recepción
    public class SelectUserRecepQuery : IRequest<PaginateResponse<IEnumerable<UserRecepDTOs>>>
    {
        public int PageNumber { get; set; } // Número de página
        public int PageSize { get; set; } // Tamaño de página
        public string? NameUser { get; set; } // Nombre de usuario a filtrar
        public bool IsDeleted { get; set; } // Indicador de si se deben incluir usuarios eliminados
        // Clase que maneja la ejecución de la consulta
        public class SelectUserRecepByQueryHandler : IRequestHandler<SelectUserRecepQuery, PaginateResponse<IEnumerable<UserRecepDTOs>>>
        {
            private readonly IRepository<DomainClass.Entity.UserRecep> _repository; // Repositorio de usuarios de recepción
            private readonly IMapper _mapper; // Objeto AutoMapper para mapeo de entidades

            public SelectUserRecepByQueryHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
            {
                _repository = repository;
                _mapper = mapper;
            }
            // Método que maneja la ejecución de la consulta
            public async Task<PaginateResponse<IEnumerable<UserRecepDTOs>>> Handle(SelectUserRecepQuery request, CancellationToken cancellationToken)
            {
                // Crear objeto de filtro de respuesta
                UserRecepResponseFilter ResponseFilter = new UserRecepResponseFilter()
                {
                    PageSize = request.PageSize,
                    PageNumber = request.PageNumber,
                    NameUser = request.NameUser,
                    IsDeleted = request.IsDeleted,
                };
                // Obtener la lista de usuarios de recepción utilizando la especificación paginada
                var UserRecep = await _repository.ListAsync(new PaginatedUserRecepSpecification(ResponseFilter));

                // Mapear la lista de usuarios de recepción a una lista de DTOs
                var UserRecepDTO = _mapper.Map<IEnumerable<UserRecepDTOs>>(UserRecep);

                // Crear una instancia de PaginateResponse que contiene la lista de DTOs y la información de paginación
                return new PaginateResponse<IEnumerable<UserRecepDTOs>>(UserRecepDTO, request.PageNumber, request.PageSize, request.IsDeleted);
            }
        }
    }
}