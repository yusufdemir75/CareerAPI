﻿using CareerAPI.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerAPI.Application.Abstraction.Token
{
    public interface  ITokenHandler
    {
        DTOs.Token CreateAccessToken(int minute,string TokenType);
    }
}
