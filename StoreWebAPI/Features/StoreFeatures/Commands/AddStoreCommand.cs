using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.StoreFeatures.Commands
{
    public record AddStoreCommand(Store Store) : IRequest  { }

    public class AddStoreCommandHandler: IRequestHandler<AddStoreCommand, Unit>
    {
        private readonly IRepository<Store> _repository;

        public AddStoreCommandHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<Unit> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            await Task.Run((System.Action)(() =>
            {
                _repository.Create((Store)request.Store);
                _repository.Save();
            }),
            cancellationToken);
            return Unit.Value;
        }
    }
}
