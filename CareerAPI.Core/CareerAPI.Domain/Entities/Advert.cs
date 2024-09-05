using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class Advert:BaseEntity
    {
        //Title
        public string title { get; set; }

        public string companyName { get; set; }

        public string position { get; set; }

        public string address { get; set; }

        public string typeOfWork { get; set; }

        public JsonDocument requirements { get; set; }

        public ICollection<Applications> Applications { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
