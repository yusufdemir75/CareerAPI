using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.Features.Queries.ApplyAdvert.GetAllApplyAdvertQuery
{
    public class GetAllApplyAdvertQueryResponse
    {
        public List<ApplyAdvertDto> ApplyAdvert { get; set; }

    }
}
