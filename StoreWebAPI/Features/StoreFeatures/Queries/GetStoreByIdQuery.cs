﻿using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.StoreFeatures.Queries
{
    public record GetStoreByIdQuery(int Id) : IRequest<Store> { }

    public class GetStoreByIdQueryHandler : IRequestHandler<GetStoreByIdQuery, Store>
    {
        private readonly IRepository<Store> repository;

        public GetStoreByIdQueryHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Store>(storeDB);
        }

        public async Task<Store> Handle(GetStoreByIdQuery request, CancellationToken cancellationToken)
        {
            return await Task.Run(() => repository.GetById(request.Id), cancellationToken);
        }
    }
}
