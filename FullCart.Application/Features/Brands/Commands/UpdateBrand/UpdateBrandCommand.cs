using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Brands.Commands.UpdateBrand
{
    public class UpdateBrandCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
    }

    public class UpdateBrandCommandHandler : IRequestHandler<UpdateBrandCommand, Response<int>>
    {
        private readonly IBrandRepositoryAsync brandRepositoryAsync;
        public UpdateBrandCommandHandler(IBrandRepositoryAsync brandRepositoryAsync)
        {
            this.brandRepositoryAsync = brandRepositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateBrandCommand command, CancellationToken cancellationToken)
        {
            var brand = await brandRepositoryAsync.GetByIdAsync(command.Id);

            if (brand == null)
            {
                throw new ApiException($"Brand Not Found.");
            }
            else
            {
                brand.Name = command.Name;
                brand.Description = command.Description;
                brand.ImageUrl = command.ImageUrl;
                await brandRepositoryAsync.UpdateAsync(brand);
                return new Response<int>(brand.Id);
            }
        }
    }
}
