using  System;
using System.Linq.Expressions;
using System.Collections.Generic;

namespace Core.Specifications
{
    public interface ISpecifications<T>
    {
        Expression<Func<T, bool>> Criteria {get;}
        List<Expression<Func<T, Object>>> Includes {get; }
    }
}