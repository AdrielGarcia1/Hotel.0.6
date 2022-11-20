using ApplicationServices.DTOs;
using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Rentals.Queries.SelectByQuery
{
    public class SelectRentalByQuery : IRequest<Response<RentalDTOs>>
    {
        public long Id { get; set; }
    }
    public class SelectRentalByQueryHandler : IRequestHandler<SelectRentalByQuery, Response<RentalDTOs>>
    {
        private readonly IRepository<Rental> _repository;
        private readonly IMapper _mapper;

        public SelectRentalByQueryHandler(IRepository<Rental> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        async Task<Response<RentalDTOs>> IRequestHandler<SelectRentalByQuery, Response<RentalDTOs>>.Handle(SelectRentalByQuery request, CancellationToken cancellationToken)
        {
            var Rental = await _repository.GetByIdAsync(request.Id);
            if (Rental == null)
            {
                throw new KeyNotFoundException($"El registro solicitado con Id {request.Id} no existe en la base de datos");
            }
            else
            {
                var dto = _mapper.Map<RentalDTOs>(Rental);
                return new Response<RentalDTOs>(dto);

            }
        }
    }
}
