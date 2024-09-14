using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Linq;
using System.Text.Json;
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

            // Update only if the request value is not null or empty
            if (!string.IsNullOrEmpty(request.age))
            {
                user.age = request.age;
            }
            if (!string.IsNullOrEmpty(request.PhoneNumber))
            {
                user.PhoneNumber = request.PhoneNumber;
            }

            if (!string.IsNullOrEmpty(request.Position))
            {
                user.position = request.Position;
            }

            if (!string.IsNullOrEmpty(request.Address))
            {
                user.address = request.Address;
            }

            if (!string.IsNullOrEmpty(request.githubLink))
            {
                user.githubLink = request.githubLink;
            }

            if (!string.IsNullOrEmpty(request.instaLink))
            {
                user.instaLink = request.instaLink;
            }

            if (!string.IsNullOrEmpty(request.twitterLink))
            {
                user.twitterLink = request.twitterLink;
            }

            if (request.skills != null)
            {
                user.skills = request.skills;
            }
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
