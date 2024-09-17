using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.DeleteAdvert
{
    public class DeleteApplyAdvertCommandRequest : IRequest<DeleteApplyAdvertCommandResponse>
    {
        public int AdvertNo { get; set; }

        public DeleteApplyAdvertCommandRequest(int advertNo)
        {
            AdvertNo = advertNo;
        }
    }
}
