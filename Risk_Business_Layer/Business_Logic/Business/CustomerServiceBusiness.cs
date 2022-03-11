﻿using Risk_Business_Layer.Business_Logic.Interfaces;
using Risk_Business_Layer.IRepositories.ICustomerService;
using Risk_Data_Access_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Business
{
    public class CustomerServiceBusiness : ICustomerServiceBusiness
    {
        private readonly ICustomerService customerService;
        private readonly RiskDbContext riskDbContext;

        public CustomerServiceBusiness(ICustomerService customerService , RiskDbContext riskDbContext)
        {
            this.customerService = customerService;
            this.riskDbContext = riskDbContext;
        }

        public async Task AddRange(ClientCustomerService model)
        {
            await riskDbContext.AddAsync(model);
           await riskDbContext.SaveChangesAsync();
        }
    }
}