using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string CategoryName { get; set; }

        public ICollection<Advert> Adverts { get; set; }
    }
}
