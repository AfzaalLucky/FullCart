using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using FullCart.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Categories.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<Response<Category>>
    {
        public int Id { get; set; }
        public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Response<Category>>
        {
            private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
            public GetCategoryByIdQueryHandler(ICategoryRepositoryAsync categoryRepositoryAsync)
            {
                this.categoryRepositoryAsync = categoryRepositoryAsync;
            }
            public async Task<Response<Category>> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                var category = await categoryRepositoryAsync.GetByIdAsync(query.Id);
                if (category == null) throw new ApiException($"Category Not Found.");
                return new Response<Category>(category);
            }
        }
    }
}
