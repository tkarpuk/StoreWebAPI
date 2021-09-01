using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using StoreWebAPI.Data;
using StoreWebAPI.Data.Repositories;
using StoreWebAPI.Models.DB;

namespace StoreWebAPI.Features.ProductFeatures.Commands
{
    public record UpdateProductCommand(Product Product) : IRequest { }

    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Unit>
    {
        private readonly IRepository<Product> repository;

        public UpdateProductCommandHandler(StoreDB storeDB)
        {
            repository = new RepositoryBase<Product>(storeDB);
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await Task.Run(() => 
            {
                repository.Update(request.Product);
                repository.Save();
            },
            cancellationToken);

            return Unit.Value;
        }
    }
}
