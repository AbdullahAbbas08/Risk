﻿using Risk_Domain_Layer.DTO_S.CallReasonClientType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface ICallReasonClientTypeBusiness
    {
        Task AddAsync(List<CallReasonClientTypeDto> model);

    }
}
 