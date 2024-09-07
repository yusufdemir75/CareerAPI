using CareerAPI.Application.Features.Commands.AppUser.CreateUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.CreateAdmin
{
    public class CreateAdminCommandHandler: IRequestHandler<CreateAdminCommandRequest, CreateAdminCommandResponse>
    {
        readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public CreateAdminCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<CreateAdminCommandResponse> Handle(CreateAdminCommandRequest request, CancellationToken cancellationToken)
        {
            IdentityResult result = await _userManager.CreateAsync(new()
            {
                Id = Guid.NewGuid().ToString(),
                UserName = request.username,
                Email = request.email,
                nameSurname = request.nameSurname,


            }, request.password);

            CreateAdminCommandResponse response = new() {Succeded = result.Succeeded};
                

            if (result.Succeeded)
            {
                response.Message = "Kullanıcı başarıyla oluşturulmuştur.";

            }
            else
                foreach (var error in result.Errors)
                {
                    response.Message += $"{error.Code} - {error.Description} ";
                }

            return response;
        }

    }
}
