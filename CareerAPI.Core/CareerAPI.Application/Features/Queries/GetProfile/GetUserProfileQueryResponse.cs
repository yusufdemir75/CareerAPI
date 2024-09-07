using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.GetProfile
{
    public class GetUserProfileQueryResponse
    {
        public string UserName { get; set; }
        public List<string> Role { get; set; }
    }
}
