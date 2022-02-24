﻿using Microsoft.AspNetCore.Http;
using Risk_Business_Layer.Services.AuthenticationModels;

namespace Risk_Business_Layer.Services.Authentication
{
    public class RegisterClientModel : RegisterModel
    {  
        [Required]
        public IFormFile Logo { get; set; }

        [Required]
        public int CityId { get; set; }

        [Required]
        public int ClientTypeId { get; set; }
    }
}