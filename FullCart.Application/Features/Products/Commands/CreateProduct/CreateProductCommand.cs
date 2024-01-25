using AutoMapper;
using FullCart.Application.Features.Brands.Commands.CreateBrand;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using FullCart.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullCart.Application.Features.Products.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        public int Quantity { get; set; }
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Response<int>>
    {
        private readonly IProductRepositoryAsync productRepositoryAsync;
        private readonly IMapper mapper;

        public CreateBrandCommandHandler(IProductRepositoryAsync productRepositoryAsync, IMapper mapper)
        {
            this.productRepositoryAsync = productRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var product = mapper.Map<Product>(request);
            await productRepositoryAsync.AddAsync(product);
            return new Response<int>(product.Id);
        }
    }
}
