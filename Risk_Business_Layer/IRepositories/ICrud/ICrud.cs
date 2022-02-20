﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Risk_Business_Layer.IUnitOfWork.ICrud
{
    public interface ICrud<T> where T : class
    {
        Task<IEnumerable<T>> GetAll(); 
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> match);
        Task<T> Find(int ID);
        Task<IEnumerable<T>> Find(Expression<Func<T, bool>> predicate);
        Task Add(T Entity);
        T Update(T Entity);
        Task<bool> Delete(int ID);
    }
}
