using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.ApplyAdvert.GetPersonelApplyAdvert
{
    public class GetPersonelApplyAdvertQueryResponse
    {
        public List<PersonelApplyAdvertDto> PersonelApplyAdvertDto { get; set; }
    }
}
