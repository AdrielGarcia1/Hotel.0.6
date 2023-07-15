using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
namespace ApplicationServices.Features.Recepcionists.Queries.SelectByQuery
{
    // Comando para realizar una consulta de un recepcionista por su Id
    public class SelectReceptionistByQuery : IRequest<Response<ReceptionistDTOs>>
    {
        public long Id { get; set; } // Id del recepcionista a consultar
    }
    public class SelectReceptionistByQueryHandler : IRequestHandler<SelectReceptionistByQuery, Response<ReceptionistDTOs>>
    {
        private readonly IRepository<Receptionist> _repository;
        private readonly IMapper _mapper;

        public SelectReceptionistByQueryHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        async Task<Response<ReceptionistDTOs>> IRequestHandler<SelectReceptionistByQuery, Response<ReceptionistDTOs>>.Handle(SelectReceptionistByQuery request, CancellationToken cancellationToken)
        {
            // Obtener el recepcionista según el Id especificado
            var Receptionist = await _repository.GetByIdAsync(request.Id);

            if (Receptionist == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                // Mapear el recepcionista a un DTO
                var dto = _mapper.Map<ReceptionistDTOs>(Receptionist);

                // Devolver una respuesta con el recepcionista DTO
                return new Response<ReceptionistDTOs>(dto);
            }
        }
    }
}