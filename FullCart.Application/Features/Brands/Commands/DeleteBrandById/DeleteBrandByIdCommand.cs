using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Brands.Commands.DeleteBrandById
{
    public class DeleteBrandByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteBrandByIdCommandHandler : IRequestHandler<DeleteBrandByIdCommand, Response<int>>
        {
            private readonly IBrandRepositoryAsync brandRepositoryAsync;
            public DeleteBrandByIdCommandHandler(IBrandRepositoryAsync brandRepositoryAsync)
            {
                this.brandRepositoryAsync = brandRepositoryAsync;
            }
            public async Task<Response<int>> Handle(DeleteBrandByIdCommand command, CancellationToken cancellationToken)
            {
                var brand = await brandRepositoryAsync.GetByIdAsync(command.Id);
                if (brand == null) throw new ApiException($"Brand Not Found.");
                await brandRepositoryAsync.DeleteAsync(brand);
                return new Response<int>(brand.Id);
            }
        }
    }
}
