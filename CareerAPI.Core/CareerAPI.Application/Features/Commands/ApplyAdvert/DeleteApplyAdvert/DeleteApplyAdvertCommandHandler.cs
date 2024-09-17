using CareerAPI.Application.Repositories.ApplyAdvert;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.DeleteAdvert
{
    public class DeleteApplyAdvertCommandHandler : IRequestHandler<DeleteApplyAdvertCommandRequest, DeleteApplyAdvertCommandResponse>
    {
        private readonly IApplyAdvertWriteRepository _applyAdvertWriteRepository;
        private readonly IApplyAdvertReadRepository _applyAdvertReadRepository;

        public DeleteApplyAdvertCommandHandler(IApplyAdvertReadRepository applyAdvertReadRepository, IApplyAdvertWriteRepository applyAdvertWriteRepository)
        {
            _applyAdvertReadRepository = applyAdvertReadRepository;
            _applyAdvertWriteRepository = applyAdvertWriteRepository;
        }

        public async Task<DeleteApplyAdvertCommandResponse> Handle(DeleteApplyAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var deleteAdvert = await _applyAdvertReadRepository.GetApplyAdvertByAdvertNoAsync(request.AdvertNo);

            if (deleteAdvert != null)
            {
                bool result = _applyAdvertWriteRepository.Remove(deleteAdvert);

                await _applyAdvertWriteRepository.SaveAsync();

                return new DeleteApplyAdvertCommandResponse
                {
                    Success = result,
                    Message = result ? "Silme işlemi başarılı." : "Silme işlemi başarısız."
                };
            }

            return new DeleteApplyAdvertCommandResponse
            {
                Success = false,
                Message = "AdvertNo ile eşleşen kayıt bulunamadı."
            };
        }
    }
}
