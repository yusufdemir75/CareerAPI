using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.AppUser.GetAllUserQuery
{
    public class GetAllUserQueryRequest:IRequest<GetAllUserQueryResponse>
    {
        public string UserName { get; }

        public GetAllUserQueryRequest(string userName)
        {
            UserName = userName;
        }
    }
}
