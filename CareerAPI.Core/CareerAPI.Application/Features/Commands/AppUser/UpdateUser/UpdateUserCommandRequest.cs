using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.AppUser.UpdateUser
{
    public class UpdateUserCommandRequest:IRequest<UpdateUserCommandResponse>
    {
        public string UserName { get; set; }
        public string Position { get; set; }
        public string Address { get; set; }
        public string age { get; set; }
        public JsonDocument skills { get; set; }

        public string githubLink { get; set; }
        public string instaLink { get; set; }
        public string twitterLink { get; set; }

        public string PhoneNumber { get; set; }

    }
}
