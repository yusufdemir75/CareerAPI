using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Domain.Entities.Identity
{
    public class AppUser : IdentityUser<string>
    {
        public string? imageUrl { get; set; } 
        public string? nameSurname { get; set; } 
        public string Role { get; set; } 

        public string? age { get; set; } 

        public string? position { get; set; } 

        public string? address { get; set; } 

        public JsonDocument? skills { get; set; } 

        public string? githubLink { get; set; } 
        public string? instaLink { get; set; } 
        public string? twitterLink { get; set; } 



    }
}
