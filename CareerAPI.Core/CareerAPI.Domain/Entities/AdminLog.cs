using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class AdminLog : BaseEntity
    {
        public string Action { get; set; }
        public User User { get; set; }
    }
}
