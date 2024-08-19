using CareerAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Abstractions
{
    public interface IAdvertService
    {
        List<Advert> GetAdvert();
    }
}
