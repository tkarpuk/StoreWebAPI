using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Commands
{
    public record DeleteProductCommand(int Id): IRequest { }

    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, Unit>
    {
        private readonly IRepository<Product> _repository;

        public DeleteProductCommandHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
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
