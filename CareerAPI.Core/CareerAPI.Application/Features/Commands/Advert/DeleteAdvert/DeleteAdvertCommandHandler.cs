using CareerAPI.Application.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.Advert.DeleteAdvert
{
    public class DeleteAdvertCommandHandler : IRequestHandler<DeleteAdvertCommandRequest, DeleteAdvertCommandResponse>
    {
        private readonly IAdvertWriteRepository _advertWriteRepository;
        private readonly IAdvertReadRepository _advertReadRepository;

        public DeleteAdvertCommandHandler(IAdvertReadRepository advertReadRepository, IAdvertWriteRepository advertWriteRepository)
        {
            _advertReadRepository = advertReadRepository;
            _advertWriteRepository = advertWriteRepository;
        }
        public async Task<DeleteAdvertCommandResponse> Handle(DeleteAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteAdvert = await _advertReadRepository.GetAdvertByAdvertNoAsync(request.AdvertNo);

            if (deleteAdvert != null)
            {
                bool result = _advertWriteRepository.Remove(deleteAdvert);

                await _advertWriteRepository.SaveAsync();

                return new DeleteAdvertCommandResponse
                {
                    Success = result,
                    Message = result ? "Silme işlemi başarılı." : "Silme işlemi başarısız."
                };
            }

            return new DeleteAdvertCommandResponse
            {
                Success = false,
                Message = "AdvertNo ile eşleşen kayıt bulunamadı."
            };
        }
    }
}
