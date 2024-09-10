using CareerAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.Advert.UpdateAdvert
{
    public class UpdateAdvertCommandHandler:IRequestHandler<UpdateAdvertCommandRequest, UpdateAdvertCommandResponse>
    {
        private readonly IAdvertReadRepository _advertReadRepository;
        private readonly IAdvertWriteRepository _advertWriteRepository;

        public UpdateAdvertCommandHandler(IAdvertReadRepository advertReadRepository, IAdvertWriteRepository advertWriteRepository)
        {
            _advertReadRepository = advertReadRepository;
            _advertWriteRepository = advertWriteRepository;
        }
        public async Task<UpdateAdvertCommandResponse> Handle(UpdateAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            // Veritabanındaki tüm ilanları getir
            var adverts = await _advertReadRepository.GetAllAsync();

            if (adverts == null || !adverts.Any())
            {
                return new UpdateAdvertCommandResponse
                {
                    Success = false,
                    Message = "No adverts found."
                };
            }

            // Tüm ilanları dolaş ve gerekiyorsa IsActive durumunu güncelle
            foreach (var advert in adverts)
            {
                if (advert.EndDate < DateTime.Now)
                {
                    advert.IsActive = false;
                    _advertWriteRepository.Update(advert);
                }
            }

            // Tüm değişiklikleri kaydet
            await _advertWriteRepository.SaveAsync();

            return new UpdateAdvertCommandResponse
            {
                Success = true,
                Message = "All adverts updated successfully."
            };
        }
    }
}
