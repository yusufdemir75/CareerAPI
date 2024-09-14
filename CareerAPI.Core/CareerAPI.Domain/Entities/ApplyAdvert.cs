using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class ApplyAdvert:BaseEntity
    {

        public string userName { get; set; }
        public string advertTitle { get; set; }
        public string nameSurname { get; set; }
        public string position { get; set; }
        public string address { get; set; }
        public JsonDocument skills { get; set; }
        public bool isApproved { get; set; }
        public string status {  get; set; }
    }
}
