using CareerAPI.Application.Abstraction.Token;
using CareerAPI.Application.DTOs;
using CareerAPI.Application.Exceptions;
using CareerAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.LoginAdmin
{
     public class LoginAdminCommandHandler : IRequestHandler<LoginAdminCommandRequest, LoginAdminCommandResponse>
        {
            readonly UserManager<Domain.Entities.Identity.AppUser> _userManager;
            readonly SignInManager<Domain.Entities.Identity.AppUser> _signInManager;
            readonly ICustomerTokenHandler _CustomerTokenHandler;
            public LoginAdminCommandHandler(UserManager<Domain.Entities.Identity.AppUser> userManager, SignInManager<Domain.Entities.Identity.AppUser> signInManager, ICustomerTokenHandler CustomerTokenHandler)
            {
                _userManager = userManager;
                _signInManager = signInManager;
                _CustomerTokenHandler = CustomerTokenHandler;
            }
            public async Task<LoginAdminCommandResponse> Handle(LoginAdminCommandRequest request, CancellationToken cancellationToken)
            {
                Domain.Entities.Identity.AppUser user = await _userManager.FindByNameAsync(request.UsernameOrEmail);

                if (user == null)
                    user = await _userManager.FindByEmailAsync(request.UsernameOrEmail);

                if (user == null)
                    throw new NotFoundUserException();


                SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, request.Password, false);
                if (result.Succeeded)//authentication başarılı!
                {
                    Token token = _CustomerTokenHandler.CreateAccessToken(5,"Admin");
                    return new LoginAdminSuccessCommandResponse()
                    {
                        token = token,
                    };
                }

                throw new AuthenticationErrorException();



            }

          
        }
    
}
