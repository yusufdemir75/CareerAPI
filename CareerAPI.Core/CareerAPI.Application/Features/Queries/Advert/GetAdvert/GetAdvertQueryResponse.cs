using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.Advert.GetAdvert
{
    public class GetAdvertQueryResponse
    {
        public List<AdvertDto> Adverts { get; set; }
    }
}
