using AutoMapper;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Categories.Queries.GetAllCategories
{
    public class GetAllCategoriesQuery : IRequest<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
    public class GetAllCategoriesQueryHandler : IRequestHandler<GetAllCategoriesQuery, PagedResponse<IEnumerable<GetAllCategoriesViewModel>>>
    {
        private readonly ICategoryRepositoryAsync categoryRepositoryAsync;
        private readonly IMapper mapper;
        public GetAllCategoriesQueryHandler(ICategoryRepositoryAsync categoryRepositoryAsync, IMapper mapper)
        {
            this.categoryRepositoryAsync = categoryRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllCategoriesViewModel>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
        {
            var validFilter = mapper.Map<GetAllCategoriesParameter>(request);
            var category = await categoryRepositoryAsync.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var categoryViewModel = mapper.Map<IEnumerable<GetAllCategoriesViewModel>>(category);
            return new PagedResponse<IEnumerable<GetAllCategoriesViewModel>>(categoryViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
