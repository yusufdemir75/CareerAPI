using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommandRequest, UpdateUserCommandResponse>
    {
        private readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;

        public UpdateUserCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<UpdateUserCommandResponse> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.UserName);

            if (user == null)
            {
                return new UpdateUserCommandResponse
                {
                    Success = false,
                    Message = "User not found"
                };
            }

            user.position = request.Position;
            user.address = request.Address;
            user.skills = request.Skills;
            user.githubLink= request.githubLink;
            user.instaLink = request.instaLink;
            user.twitterLink = request.twitterLink;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                return new UpdateUserCommandResponse
                {
                    Success = true,
                    Message = "User updated successfully"
                };
            }

            return new UpdateUserCommandResponse
            {
                Success = false,
                Message = string.Join(", ", result.Errors.Select(e => e.Description))
            };
        }
    }
}
