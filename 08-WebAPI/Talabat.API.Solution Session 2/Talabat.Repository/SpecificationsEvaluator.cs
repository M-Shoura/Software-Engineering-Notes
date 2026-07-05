using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Specifications;

namespace Talabat.Repository
{
    public static class SpecificationsEvaluator<TEntity> where TEntity : BaseEntity
    {
        //                                          _dbContext.Set<TEntity>         object having specs : Where , Include , ... 
        public static IQueryable<TEntity> GetQuery(IQueryable<TEntity> inputQuery , ISpecifications<TEntity> spec)
        {
            var query = inputQuery;         // _dbContext.Set<TEntity>   

            if(spec.Criteria != null)
                query = query.Where(spec.Criteria);

            query = spec.Includes.Aggregate(query, (currentExpression, includeExpression) => currentExpression.Include(includeExpression));
            
            // or

            // foreach(var exp in spec.Includes)
            // {
            //     query = query.Include(exp);
            // }

            return query;
        }
    }
}
