using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;
using System.Linq;

namespace StoreWebAPI.Features.ProductFeatures.Queries
{
    public record GetProductsQuery(int page, int pageSize) : IRequest<IEnumerable<Product>> { }

    public class GetProductsQueryHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly IRepository<Product> repository;

        public GetProductsQueryHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            int page = request.page;
            int pageSize = request.pageSize;

            var pageItems = await Task.Run(() =>
            {
                var list = repository.GetAll();
                var count = list.Count();
                if (count < pageSize)
                    return list;

                return list.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            }, 
            cancellationToken);

            return pageItems;
        }
    }
}
