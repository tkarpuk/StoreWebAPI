using StoreWebAPI.Models.DB;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using System.Threading;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Data;

namespace StoreWebAPI.Features.StoreFeatures.Queries
{
    public record GetStoresQuery() : IRequest<IEnumerable<Store>> {}

    public class GetStoresQueryHandler : IRequestHandler<GetStoresQuery, IEnumerable<Store>>
    {
        private readonly IRepository<Store> _repository;

        public GetStoresQueryHandler(StoreDB storeDB)
        {
            _repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<IEnumerable<Store>> Handle(GetStoresQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => _repository.GetAll(), cancellationToken);
        }
    }
}
