using ApplicationServices.Interfaces;
using ApplicationServices.Wrappers;
using AutoMapper;
using DomainClass.Entity;
using MediatR;

namespace ApplicationServices.Features.Recepcionists.Commands.UpdateRecepcionistCommand
{
    public class UpdateRecepcionistCommand : IRequest<Response<long>>
    {
        public long Id { get; set; }
        public string NameRecep { get; set; }
        public string LastNameRecep { get; set; }
        public string RDirection { get; set; }
        public string EmailRecep { get; set; }
        public string DocumentRecep { get; set; }
        public string TelephoneRecep { get; set; }
        public string Estate { get; set; }
        public string Observation { get; set; }
        public long UserRecepId { get; set; }
    }
    public class UpdateRecepcionistCommandHandler : IRequestHandler<UpdateRecepcionistCommand, Response<long>>
    {
        private readonly IRepository<Receptionist> _repository;
       

        public UpdateRecepcionistCommandHandler(IRepository<Receptionist> repository, IMapper mapper)
        {
            _repository = repository;
        }

        public async Task<Response<long>> Handle(UpdateRecepcionistCommand request, CancellationToken cancellationToken)
        {
            var Receptionist = await _repository.GetByIdAsync(request.Id);

            if (Receptionist == null)
            {
                throw new KeyNotFoundException($"Registro no encontrado con el Id {request.Id}");
            }else
            {
                Receptionist.NameRecep = request.NameRecep;
                Receptionist.LastNameRecep = request.LastNameRecep;
                Receptionist.RDirection = request.RDirection;
                Receptionist.EmailRecep = request.EmailRecep;
                Receptionist.DocumentRecep = request.DocumentRecep;
                Receptionist.TelephoneRecep= request.TelephoneRecep;
                Receptionist.Estate = request.Estate;
                Receptionist.Observation= request.Observation;
                Receptionist.UserRecepId = request.UserRecepId;

                await _repository.UpdateAsync(Receptionist);
                
            }
            return new Response<long>(Receptionist.Id);
        }
    }
}
