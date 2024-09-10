using CareerAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.Advert.CreateAdvert
{
    public class CreateAdvertCommandHandler : IRequestHandler<CreateAdvertCommandRequest, CreateAdvertCommandResponse>
    {
        private readonly IAdvertWriteRepository _advertWriteRepository;
        private readonly IAdvertReadRepository _advertReadRepository;

        public CreateAdvertCommandHandler(IAdvertWriteRepository advertWriteRepository, IAdvertReadRepository advertReadRepository)
        {
            _advertWriteRepository = advertWriteRepository;
            _advertReadRepository = advertReadRepository;
        }

        public async Task<CreateAdvertCommandResponse> Handle(CreateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var advert = new Domain.Entities.Advert
            {
                companyName = request.companyName,
                title = request.title,
                address = request.Address,
                position = request.position,
                typeOfWork = request.typeOfWork,
                requirements = request.requirements,
                IsActive = request.IsActive,
                EndDate = request.EndDate,
                CreatedDate = request.CreatedDate,
            };

            await _advertWriteRepository.AddAsync(advert);
            await _advertWriteRepository.SaveAsync();

            return new CreateAdvertCommandResponse
            {
                Success = true,
                Message = "ilan başarıyla oluşturuldu."
            };
        }
    }
}
