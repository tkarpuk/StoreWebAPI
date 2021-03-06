using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Queries
{
    public record GetProductByIdQuery(int Id) : IRequest<Product> { }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly IRepository<Product> _repository;

        public GetProductByIdQueryHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _repository.GetById(request.Id), cancellationToken);
        }
    }
}
