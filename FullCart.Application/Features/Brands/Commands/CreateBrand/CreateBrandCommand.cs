using AutoMapper;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using FullCart.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Brands.Commands.CreateBrand
{
    public partial class CreateBrandCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, Response<int>>
    {
        private readonly IBrandRepositoryAsync brandRepositoryAsync;
        private readonly IMapper mapper;

        public CreateBrandCommandHandler(IBrandRepositoryAsync brandRepositoryAsync, IMapper mapper)
        {
            this.brandRepositoryAsync = brandRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
        {
            var brand = mapper.Map<Brand>(request);
            await brandRepositoryAsync.AddAsync(brand);
            return new Response<int>(brand.Id);
        }
    }
}
