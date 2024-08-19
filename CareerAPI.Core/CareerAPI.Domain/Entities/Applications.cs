using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class Applications : BaseEntity
    {
        public string Status { get; set; }

        public Advert Advert { get; set; }

        public Applications Application { get; set; }
    }
}
