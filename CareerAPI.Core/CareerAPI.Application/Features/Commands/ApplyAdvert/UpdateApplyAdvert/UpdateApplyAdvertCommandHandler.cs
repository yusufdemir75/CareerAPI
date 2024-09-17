using CareerAPI.Application.Repositories.ApplyAdvert;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.UpdateApplyAdvert
{
    public class UpdateApplyAdvertCommandHandler : IRequestHandler<UpdateApplyAdvertCommandRequest, UpdateApplyAdvertCommandResponse>
    {
        private readonly IApplyAdvertReadRepository _applyAdvertReadRepository;
        private readonly IApplyAdvertWriteRepository _applyAdvertWriteRepository;

        public UpdateApplyAdvertCommandHandler(IApplyAdvertWriteRepository applyAdvertWriteRepository, IApplyAdvertReadRepository applyAdvertReadRepository)
        {
            _applyAdvertWriteRepository = applyAdvertWriteRepository;
            _applyAdvertReadRepository = applyAdvertReadRepository;
        }

        public async Task<UpdateApplyAdvertCommandResponse> Handle(UpdateApplyAdvertCommandRequest request, CancellationToken cancellationToken)
        {
            var applyAdvert = await _applyAdvertReadRepository.GetWhere(x => x.AdvertNo == request.advertNo)
                                                     .FirstOrDefaultAsync();

            if (applyAdvert == null)
            {
                return new UpdateApplyAdvertCommandResponse
                {
                    Success = false,
                    Message = "Advert not found."
                };
            }

            applyAdvert.status = request.status;
            applyAdvert.isApproved = request.isApproved;

            await _applyAdvertWriteRepository.SaveAsync();

            return new UpdateApplyAdvertCommandResponse
            {
                Success = true,
                Message = "Advert updated successfully."
            };
        }
    }
}
