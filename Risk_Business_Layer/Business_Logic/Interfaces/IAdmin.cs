using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.Business_Logic.Interfaces
{
    public interface IAdmin<T> where T : class
    {
        Task<T> AssignClientToAgent(T Entity);

    }
}
