using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.AppUser.GetUserRoleQuery
{
    public class GetUserRoleQueryRequest:IRequest<GetUserRoleQueryResponse>
    {
        public string UserName { get; }

        public GetUserRoleQueryRequest(string userName)
        {
            UserName = userName;
        }

    }
}
