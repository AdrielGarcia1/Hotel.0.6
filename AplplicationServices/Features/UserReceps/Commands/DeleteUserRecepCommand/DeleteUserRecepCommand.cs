using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using DomainClass.Entity;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationServices.Features.UserReceps.Commands.DeleteUserRecepCommand
{
    public class DeleteUserRecepCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
    }
    public class DeleteUserRecepCommandHandler : IRequestHandler<DeleteUserRecepCommand, Response<long>>
    {
        private readonly IRepository<DomainClass.Entity.UserRecep> _repository;
        public DeleteUserRecepCommandHandler(IRepository<DomainClass.Entity.UserRecep> repository)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(DeleteUserRecepCommand request, CancellationToken cancellationToken)
        {
            var UserRecep = await _repository.GetByIdAsync(request.Id);

            if (UserRecep == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }
            else
            {
                await _repository.DeleteAsync(UserRecep);
                return new Response<long>(UserRecep.Id);
            }
        }
    }
}
