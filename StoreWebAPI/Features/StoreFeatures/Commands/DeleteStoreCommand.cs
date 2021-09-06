using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.StoreFeatures.Commands
{
    public record DeleteStoreCommand(int Id) : IRequest { }

    public class DeleteStoreCommandHandler : IRequestHandler<DeleteStoreCommand, Unit>
    {
        private readonly IRepository<Store> _repository;

        public DeleteStoreCommandHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<Unit> Handle(DeleteStoreCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _repository.DelteById(request.Id);
                _repository.Save();
            },
            cancellationToken);

            return Unit.Value;
        }
    }
}
