﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface ICustomerServiceBusiness
    {
        Task AddRange(ClientCustomerService model);
    }
}