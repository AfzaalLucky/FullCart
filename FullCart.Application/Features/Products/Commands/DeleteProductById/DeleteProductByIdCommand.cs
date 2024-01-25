using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Products.Commands.DeleteProductById
{
    public class DeleteProductByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteProductByIdCommandHandler : IRequestHandler<DeleteProductByIdCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync productRepository;
            public DeleteProductByIdCommandHandler(IProductRepositoryAsync productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<Response<int>> Handle(DeleteProductByIdCommand command, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(command.Id);
                if (product == null) throw new ApiException($"Product Not Found.");
                await productRepository.DeleteAsync(product);
                return new Response<int>(product.Id);
            }
        }
    }
}
