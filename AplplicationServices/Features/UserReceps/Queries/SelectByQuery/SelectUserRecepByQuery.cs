using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.UserReceps.Queries.SelectByQuery
{
    // Clase que representa la consulta para seleccionar un usuario de recepción por su Id
    public class SelectUserRecepByQuery : IRequest<Response<UserRecepDTOs>>
    {
        public long Id { get; set; } // Id del usuario de recepción a seleccionar
    }

    // Clase que maneja la ejecución de la consulta
    public class SelectUserRecepByQueryHandler : IRequestHandler<SelectUserRecepByQuery, Response<UserRecepDTOs>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository; // Repositorio de usuarios de recepción
        private readonly IMapper _mapper; // Objeto AutoMapper para mapeo de entidades

        public SelectUserRecepByQueryHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        // Método que maneja la ejecución de la consulta
        async Task<Response<UserRecepDTOs>> IRequestHandler<SelectUserRecepByQuery, Response<UserRecepDTOs>>.Handle(SelectUserRecepByQuery request, CancellationToken cancellationToken)
        {
            // Obtener el usuario de recepción por su Id utilizando el repositorio
            var UserRecep = await _repository.GetByIdAsync(request.Id);

            if (UserRecep == null)
            {
                // Si el usuario de recepción no existe, lanzar una excepción indicando que no se encontró el registro
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Si se encuentra el usuario de recepción, mapear la entidad a un DTO
                var dto = _mapper.Map<UserRecepDTOs>(UserRecep);

                // Devolver una instancia de Response que contiene el DTO como resultado de la consulta
                return new Response<UserRecepDTOs>(dto);
            }
        }
    }
}