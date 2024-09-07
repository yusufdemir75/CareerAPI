using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.LoginAdmin
{
    public class LoginAdminCommandResponse
    {

    }
    public class LoginAdminSuccessCommandResponse : LoginAdminCommandResponse
    {
        public Token token { get; set; }

    }
    public class LoginAdminErrorCommandResponse : LoginAdminCommandResponse
    {
        public string Message { get; set; }
    }
}
