using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.UpdateApplyAdvert
{
    public class UpdateApplyAdvertCommandRequest:IRequest<UpdateApplyAdvertCommandResponse>
    {
        public int advertNo { get; set; }
        public string status { get; set; }
        public bool isApproved { get; set; }
    }
}
