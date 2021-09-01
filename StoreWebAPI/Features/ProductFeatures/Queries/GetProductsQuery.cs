using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Queries
{
    public record GetProductsQuery : IRequest<IEnumerable<Product>> { }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IRepository<Product> repository;

        public GetProductsQueryHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => repository.GetAll(), cancellationToken);
        }
    }
}
