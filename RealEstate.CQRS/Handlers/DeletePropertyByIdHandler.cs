using MediatR;
using RealEstate.CQRS.Commands;
using RealEstate.CQRS.Responses;
using RealEstate.Infrastructure.Data;
using RealEstate.Infrastructure.Data.Repositories;

namespace RealEstate.CQRS.Handlers
{
    public class DeletePropertyByIdHandler : IRequestHandler<DeletePropertyByIdCommand, Response>
    {
        private readonly IApplicationDbRepository repo;

        public DeletePropertyByIdHandler(IApplicationDbRepository _repo)
        {
            repo = _repo;
        }

        public Task<Response> Handle(DeletePropertyByIdCommand request, CancellationToken cancellationToken)
        {
            int id = request.Id;
            var property = repo.GetByIdAsync<Property>(id);
            repo.DeleteAsync<Property>(property);

            return (Task<Response>)Task.CompletedTask;
        }
    }
}
