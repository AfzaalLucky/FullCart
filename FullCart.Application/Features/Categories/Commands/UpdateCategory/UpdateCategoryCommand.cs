using FullCart.Application.Exceptions;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }

    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        public UpdateCategoryCommandHandler(ICategoryRepositoryAsync categoryRepositoryAsync)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
        }
        public async Task<Response<int>> Handle(UpdateCategoryCommand command, CancellationToken cancellationToken)
        {
            var category = await categoryRepositoryAsync.GetByIdAsync(command.Id);

            if (category == null)
            {
                throw new ApiException($"Category Not Found.");
            }
            else
            {
                category.Name = command.Name;
                category.Description = command.Description;
                await categoryRepositoryAsync.UpdateAsync(category);
                return new Response<int>(category.Id);
            }
        }
    }
}
