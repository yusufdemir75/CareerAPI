using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.Advert.GetActiveAdvert
{
    public class GetActiveAdvertQueryResponse
    {
        public List<AdvertDto> Adverts { get; set; }

    }
}
