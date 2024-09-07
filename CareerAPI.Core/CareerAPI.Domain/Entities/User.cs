using CareerAPI.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }

        public string Email { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

        public bool IsActive { get; set; }

        public ICollection<Applications> Applications { get; set; }

        public ICollection<AdminLog> AdminLogs { get; set; }

        public ICollection<Advert> Adverts { get; set; }
    }
}
