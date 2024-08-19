using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class Advert:BaseEntity
    {
        //Title
        public string Title { get; set; }

        public string Description { get; set; }

        public string Address { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }

        public User Users { get; set; }

        public ICollection<Applications> Applications { get; set; }

        public ICollection<Category> Categories { get; set; }
    }
}
