using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using FullCart.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Brands.Queries.GetBrandById
{
    public class GetBrandByIdQuery : IRequest<Response<Brand>>
    {
        public int Id { get; set; }
        public class GetBrandByIdQueryHandler : IRequestHandler<GetBrandByIdQuery, Response<Brand>>
        {
            private readonly IBrandRepositoryAsync brandRepositoryAsync;
            public GetBrandByIdQueryHandler(IBrandRepositoryAsync brandRepositoryAsync)
            {
                this.brandRepositoryAsync = brandRepositoryAsync;
            }
            public async Task<Response<Brand>> Handle(GetBrandByIdQuery query, CancellationToken cancellationToken)
            {
                var brand = await brandRepositoryAsync.GetByIdAsync(query.Id);
                if (brand == null) throw new ApiException($"Brand Not Found.");
                return new Response<Brand>(brand);
            }
        }
    }
}
