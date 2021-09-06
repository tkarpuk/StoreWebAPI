using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.StoreFeatures.Commands
{
    public record UpdateStoreCommand(Store Store) : IRequest { }

    public class UpdateStoreCommandHandler : IRequestHandler<UpdateStoreCommand, Unit>
    {
        private readonly IRepository<Store> _repository;

        public UpdateStoreCommandHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<Unit> Handle(UpdateStoreCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                _repository.Update(request.Store);
                _repository.Save();
            },
            cancellationToken);

            return Unit.Value;
        }
    }
}
