using AutoMapper;
using FullCart.Application.Features.Brands.Commands.CreateBrand;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using FullCart.Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Categories.Commands.CreateCategory
{
    public class CreateCategoryCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Response<int>>
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        private readonly IMapper mapper;

        public CreateCategoryCommandHandler(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = mapper.Map<Category>(request);
            await categoryRepositoryAsync.AddAsync(category);
            return new Response<int>(category.Id);
        }
    }
}
