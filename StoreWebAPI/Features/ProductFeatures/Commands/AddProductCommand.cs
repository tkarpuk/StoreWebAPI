using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Commands
{
    public record AddProductCommand(Product Product) : IRequest { }

    public class AddProductCommandHandler : IRequestHandler<AddProductCommand, Unit>
    {
        private readonly IRepository<Product> repository;

        public AddProductCommandHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<Unit> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() =>
            {
                repository.Create(request.Product);
                repository.Save();
            },
            cancellationToken);

            return Unit.Value;
        }
    }
}
