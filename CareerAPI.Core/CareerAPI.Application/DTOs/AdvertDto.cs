using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.DTOs
{
    public class AdvertDto
    {
        public Guid Id { get; set; }

        public int advertNo { get; set; }
        public string CompanyName { get; set; }
        public string Title { get; set; }
        public string Address { get; set; }
        public string Position { get; set; }
        public string TypeOfWork { get; set; }

        public DateTime EndDate { get; set; }
        public JsonDocument Requirements { get; set; }
        public bool IsActive { get; set; }
    }
}
