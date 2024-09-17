using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.ApplyAdvert.GetPersonelApplyAdvert
{
    public class GetPersonelApplyAdvertQueryRequest:IRequest<GetPersonelApplyAdvertQueryResponse>
    {
        public string? UserName { get; set; }
    }
}
