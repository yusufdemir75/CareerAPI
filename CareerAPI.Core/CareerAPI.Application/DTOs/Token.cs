using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.DTOs
{
    public class Token
    {
        public string accessToken { get; set; }

        public DateTime Expiration { get; set; }

    }
}
