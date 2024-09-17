using CareerAPI.Application.Repositories;
using CareerAPI.Application.Repositories.ApplyAdvert;
using MediatR;
using Microsoft.AspNetCore.Identity;
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
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;


        public CreateApplyAdvertCommandHandler(IApplyAdvertWriteRepository applyAdvertWriteRepository, IApplyAdvertReadRepository applyAdvertReadRepository, UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _applyAdvertWriteRepository = applyAdvertWriteRepository;
            _applyAdvertReadRepository = applyAdvertReadRepository;
            _userManager = userManager;
        }
        public async Task<CreateApplyAdvertCommandResponse> Handle(CreateApplyAdvertCommandRequest request, CancellationToken cancellationToken)
        {

            var CVrl = await _userManager.FindByNameAsync(request.userName);

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
                advertTitle = request.advertTitle,
                nameSurname = request.nameSurname,
                position = request.position,
                address = request.address,
                skills = request.skills,
                CreatedDate = request.CreatedDate,
                status = request.status,
                isApproved = request.isApproved,
                cvUrl = CVrl.cvUrl,
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
