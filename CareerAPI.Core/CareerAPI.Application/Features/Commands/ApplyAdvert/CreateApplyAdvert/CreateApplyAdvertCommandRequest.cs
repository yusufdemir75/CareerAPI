using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.ApplyAdvert.CreateApplyAdvert
{
    public class CreateApplyAdvertCommandRequest:IRequest<CreateApplyAdvertCommandResponse>
    {

        public string userName { get; set; }
        public string advertTitle { get; set; }

        public string nameSurname { get; set; }

        public string position { get; set; }

        public string address { get; set; }

        public JsonDocument skills { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

        public bool isApproved { get; set; } = false;

        public string status { get; set; } = "İlan Beklemede";

    }
}
