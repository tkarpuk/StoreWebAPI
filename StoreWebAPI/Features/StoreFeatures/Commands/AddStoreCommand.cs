using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.StoreFeatures.Commands
{
    public record AddStoreCommand(Store store) : IRequest  { }

    public class AddStoreCommandHandler: IRequestHandler<AddStoreCommand, Unit>
    {
        private readonly IRepository<Store> repository;

        public AddStoreCommandHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<Unit> Handle(AddStoreCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                repository.Create(request.store);
                repository.Save();
            },
            cancellationToken);
            return Unit.Value;
        }
    }
}
