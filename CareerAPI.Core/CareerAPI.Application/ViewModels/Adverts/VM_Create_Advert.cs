using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CareerAPI.Application.ViewModels.Adverts
{
    public class VM_Create_Advert
    {
        public string title { get; set; }

        public string companyName { get; set; }

        public string position { get; set; }

        public string Address { get; set; }

        public string typeOfWork { get; set; }

        public JsonDocument requirements { get; set; }
    }
}
