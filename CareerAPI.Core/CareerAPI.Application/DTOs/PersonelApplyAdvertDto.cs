using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.DTOs
{
    public class PersonelApplyAdvertDto
    {
        public int advertNo { get; set; }
        public string? cvUrl { get; set; }
        public string? userName { get; set; }
        public string? advertTitle { get; set; }

        public string? nameSurname { get; set; }

        public bool isApproved { get; set; }

        public string? status { get; set; }

        public string? position { get; set; }

        public string? address { get; set; }

        public JsonDocument? skills { get; set; }
    }
}
