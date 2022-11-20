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

namespace ApplicationServices.Features.UserReceps.Commands.UpdateUserRecepCommand
{
    public class UpdateUserRecepCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string? NameUser { get; set; }
        public string? Password { get; set; }
        public string? EmailRecep { get; set; }
    }
    public class UpdateUserRecepCommandHandler : IRequestHandler<UpdateUserRecepCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository;

        public UpdateUserRecepCommandHandler(IRepository<DomainClass.Entity.UserRecep> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(UpdateUserRecepCommand request, CancellationToken cancellationToken)
        {
            var UserRecep = await _repository.GetByIdAsync(request.Id);

            if (UserRecep == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                UserRecep.NameUser = request.NameUser;
                UserRecep.Password = request.Password;
                UserRecep.EmailRecep = request.EmailRecep;

                await _repository.UpdateAsync(UserRecep);
                
            }
         return new Response<long>(UserRecep.Id);
        }
    }
}
