using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.DTOs
{
    public class ApplyAdvertDto
    {
        public Guid id { get; set; }
        public string userName { get; set; }
        public string advertTitle { get; set; }

        public string nameSurname { get; set; }

        public string position { get; set; }

        public string address { get; set; }

        public JsonDocument skills { get; set; }
    }
}
