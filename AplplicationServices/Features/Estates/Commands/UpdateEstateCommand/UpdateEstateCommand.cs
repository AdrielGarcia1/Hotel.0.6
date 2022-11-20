using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.Estates.Commands.UpdateEstateCommand
{
    public class UpdateEstateCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string NameEstate { get; set; }
    }
    public class UpdateEstateCommandHandler : IRequestHandler<UpdateEstateCommand, Response<long>>
    {
        private readonly IRepository<Estate> _repository;
        
        public UpdateEstateCommandHandler(IRepository<Estate> repository, IMapper mapper)
        {
            _repository = repository;
            
        }

        public async Task<Response<long>> Handle(UpdateEstateCommand request, CancellationToken cancellationToken)
        {
            var Estate = await _repository.GetByIdAsync(request.Id);

            if (Estate == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                Estate.NameEstate = request.NameEstate;

                await _repository.UpdateAsync(Estate);
              
            }
            return new Response<long>(Estate.Id);
        }
    }
}
