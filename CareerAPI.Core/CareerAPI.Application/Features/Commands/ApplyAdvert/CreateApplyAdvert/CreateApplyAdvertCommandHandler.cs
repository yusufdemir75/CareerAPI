using CareerAPI.Application.Repositories;
using CareerAPI.Application.Repositories.ApplyAdvert;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.CreateApplyAdvert
{
    public class CreateApplyAdvertCommandHandler : IRequestHandler<CreateApplyAdvertCommandRequest, CreateApplyAdvertCommandResponse>
    {
        private readonly IApplyAdvertWriteRepository _applyAdvertWriteRepository;
        private readonly IApplyAdvertReadRepository _applyAdvertReadRepository;


        public CreateApplyAdvertCommandHandler(IApplyAdvertWriteRepository applyAdvertWriteRepository, IApplyAdvertReadRepository applyAdvertReadRepository)
        {
            _applyAdvertWriteRepository = applyAdvertWriteRepository;
            _applyAdvertReadRepository = applyAdvertReadRepository;
        }
        public async Task<CreateApplyAdvertCommandResponse> Handle(CreateApplyAdvertCommandRequest request, CancellationToken cancellationToken)
        {

            var existingApplication = await _applyAdvertReadRepository
                            .GetSingleAsync(a => a.advertTitle == request.advertTitle && a.nameSurname == request.nameSurname);

            if (existingApplication != null)
            {
                return new CreateApplyAdvertCommandResponse
                {
                    Success = false,
                    Message = "Aynı ilana birden fazla başvuramazsınız."
                };
            }

            var applyAdvert = new Domain.Entities.ApplyAdvert
            {
                userName = request.userName,
                advertTitle= request.advertTitle,
                nameSurname= request.nameSurname,
                position= request.position,
                address= request.address,
                skills= request.skills,
                CreatedDate=request.CreatedDate,
                status=request.status,
                isApproved=request.isApproved,
            };

            await _applyAdvertWriteRepository.AddAsync(applyAdvert);
            await _applyAdvertWriteRepository.SaveAsync();

            return new CreateApplyAdvertCommandResponse
            {
                Success = true,
                Message = "ilan başarıyla oluşturuldu."

            };
        }
    }
}
