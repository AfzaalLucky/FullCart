using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Categories.Commands.DeleteCategoryById
{
    public class DeleteCategoryByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteCategoryByIdCommandHandler : IRequestHandler<DeleteCategoryByIdCommand, Response<int>>
        {
            private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
            public DeleteCategoryByIdCommandHandler(ICategoryRepositoryAsync categoryRepositoryAsync)
            {
                this.categoryRepositoryAsync = categoryRepositoryAsync;
            }
            public async Task<Response<int>> Handle(DeleteCategoryByIdCommand command, CancellationToken cancellationToken)
            {
                var category = await categoryRepositoryAsync.GetByIdAsync(command.Id);
                if (category == null) throw new ApiException($"Category Not Found.");
                await categoryRepositoryAsync.DeleteAsync(category);
                return new Response<int>(category.Id);
            }
        }
    }
}
