using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Commands.Advert.CreateAdvert
{
    public class CreateAdvertCommandRequest:IRequest<CreateAdvertCommandResponse>
    {
        
        public string title { get; set; }

        public string companyName { get; set; }

        public string position { get; set; }

        public string Address { get; set; }

        public string typeOfWork { get; set; }

        public JsonDocument requirements { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime EndDate { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;

    }
}
