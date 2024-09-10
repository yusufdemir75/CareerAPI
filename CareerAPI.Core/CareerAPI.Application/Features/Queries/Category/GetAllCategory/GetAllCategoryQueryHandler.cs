using CareerAPI.Application.Repositories;
using CareerAPI.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.Category.GetAllCategory
{
    public class GetAllProductQueryHandler : IRequestHandler<GetAllCategoryQueryRequest, GetAllCategoryQueryResponse>
    {
        readonly ICategoryReadRepository _categoryReadRepository;

        public GetAllProductQueryHandler(ICategoryReadRepository categoryReadRepository)
        {
            _categoryReadRepository = categoryReadRepository;
        }

        public Task<GetAllCategoryQueryResponse> Handle(GetAllCategoryQueryRequest request, CancellationToken cancellationToken)
        {

            var categories = _categoryReadRepository.GetAll(false).Select(
                c => new
                {
                    c.Id,
                    c.CreatedDate,
                    c.CategoryName
                }).ToList();

            // Response nesnesi oluşturma
            var response = new GetAllCategoryQueryResponse
            {
                Categories = categories
            };


            return Task.FromResult(response);
        }
    }
}
