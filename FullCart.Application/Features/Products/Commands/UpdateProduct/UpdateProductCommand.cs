using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, Response<int>>
        {
            private readonly IProductRepositoryAsync productRepository;
            public UpdateProductCommandHandler(IProductRepositoryAsync productRepository)
            {
                this.productRepository = productRepository;
            }
            public async Task<Response<int>> Handle(UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var product = await productRepository.GetByIdAsync(command.Id);

                if (product == null)
                {
                    throw new ApiException($"Product Not Found.");
                }
                else
                {
                    product.Name = command.Name;
                    product.Description = command.Description;
                    product.ImageUrl = command.ImageUrl;
                    product.Quantity = command.Quantity;
                    product.BrandId = command.BrandId;
                    product.CategoryId = command.CategoryId;
                    await productRepository.UpdateAsync(product);
                    return new Response<int>(product.Id);
                }
            }
        }
    }
}
