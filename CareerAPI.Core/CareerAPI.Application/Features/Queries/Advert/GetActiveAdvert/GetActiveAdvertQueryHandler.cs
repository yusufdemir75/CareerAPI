using CareerAPI.Application.DTOs;
using CareerAPI.Application.Features.Queries.Advert.GetAdvert;
using CareerAPI.Application.Repositories;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.Advert.GetActiveAdvert
{
    public class GetActiveAdvertQueryHandler : IRequestHandler<GetActiveAdvertQueryRequest, GetActiveAdvertQueryResponse>
    {
        private readonly IAdvertReadRepository _advertReadRepository;

        public GetActiveAdvertQueryHandler(IAdvertReadRepository advertReadRepository)
        {
            _advertReadRepository = advertReadRepository;
        }

        public async Task<GetActiveAdvertQueryResponse> Handle(GetActiveAdvertQueryRequest request, CancellationToken cancellationToken)
        {
            // Yalnızca aktif ilanları filtrele
            var adverts = _advertReadRepository.GetAll(false)
                .Where(a => a.IsActive) // Sadece IsActive true olan ilanları al
                .OrderBy(a => a.CreatedDate)
                .ToList();

            var response = new GetActiveAdvertQueryResponse
            {
                Adverts = adverts.Select(a => new AdvertDto
                {
                    Id = a.Id,
                    CompanyName = a.companyName,
                    Title = a.title,
                    Address = a.address,
                    Position = a.position,
                    TypeOfWork = a.typeOfWork,
                    Requirements = a.requirements,
                    IsActive = a.IsActive
                }).ToList()
            };

            return response;
        }
    }
}
