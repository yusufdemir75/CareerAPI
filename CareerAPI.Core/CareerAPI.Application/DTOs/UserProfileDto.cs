using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CareerAPI.Application.DTOs
{
    public class UserProfileDto
    {
        public string address { get; set; }

        public DateTime birthDate { get; set; }

        public string position { get; set; }

        public JsonDocument skills { get; set; }

        public string githubLink { get; set; }

        public string instaLink { get; set; }

        public string twitterLink { get; set; }
    }
}
