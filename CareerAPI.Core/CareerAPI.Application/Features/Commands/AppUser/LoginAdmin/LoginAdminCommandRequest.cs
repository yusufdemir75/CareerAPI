using CareerAPI.Application.Features.Commands.AppUser.LoginUser;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.LoginAdmin
{
    public class LoginAdminCommandRequest : IRequest<LoginAdminCommandResponse>
    {
        public string UsernameOrEmail { get; set; }
        public string Password { get; set; }


    }
}
