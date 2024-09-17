using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.Advert.DeleteAdvert
{
    public class DeleteAdvertCommandRequest:IRequest<DeleteAdvertCommandResponse>
    {
        public int AdvertNo { get; set; }

        public DeleteAdvertCommandRequest(int advertNo)
        {
            AdvertNo = advertNo;
        }
    }
}
