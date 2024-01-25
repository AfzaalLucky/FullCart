
using AutoMapper;
using FullCart.Application.Interfaces.Repositories;
using FullCart.Application.Wrappers;
using MediatR;
using System;
using System.Linq;

namespace FullCart.Application.Features.Brands.Queries.GetAllBrands
{
    public class GetAllBrandsQuery : IRequest<PagedResponse<IEnumerable<GetAllBrandsViewModel>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllBrandsQueryHandler : IRequestHandler<GetAllBrandsQuery, PagedResponse<IEnumerable<GetAllBrandsViewModel>>>
    {
        private readonly IBrandRepositoryAsync brandRepositoryAsync;
        private readonly IMapper mapper;
        public GetAllBrandsQueryHandler(IBrandRepositoryAsync brandRepositoryAsync, IMapper mapper)
        {
            this.brandRepositoryAsync = brandRepositoryAsync;
            this.mapper = mapper;
        }

        public async Task<PagedResponse<IEnumerable<GetAllBrandsViewModel>>> Handle(GetAllBrandsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = mapper.Map<GetAllBrandsParameter>(request);
            var brand = await brandRepositoryAsync.GetPagedReponseAsync(validFilter.PageNumber, validFilter.PageSize);
            var brandsViewModel = mapper.Map<IEnumerable<GetAllBrandsViewModel>>(brand);
            return new PagedResponse<IEnumerable<GetAllBrandsViewModel>>(brandsViewModel, validFilter.PageNumber, validFilter.PageSize);
        }
    }
}
