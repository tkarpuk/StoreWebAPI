using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Queries
{
    public record GetProductById(int Id) : IRequest<Product> { }

    public class GetProductByIdHandler : IRequestHandler<GetProductById, Product>
    {
        private readonly IRepository<Product> repository;

        public GetProductByIdHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<Product> Handle(GetProductById request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => repository.GetById(request.Id), cancellationToken);
        }
    }
}
