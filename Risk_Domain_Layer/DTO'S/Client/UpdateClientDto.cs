using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;

namespace Risk_Domain_Layer.DTO_S.Client
{
    public class UpdateClientDto
    {
        public string Id { get; set; }
        public string? LogoPath { get; set; }
        public IFormFile? Logo { get; set; }
        public int CityId { get; set; }

        public int ClientTypeId { get; set; }
        public string Name { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }
        public string Role { get; set; }
    }
}
