using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;

namespace Talabat.Core.Specifications
{
    public interface ISpecifications<T> where T : BaseEntity
    {
        // We will work today only for "Where" and "Include"
        public Expression<Func<T,bool>>? Criteria { get; set; }      // ex: P => P.Id == 1   , Note : can be Predicate<bool> also
        public List<Expression<Func<T,object>>> Includes { get; set; }
        
        // can be IEnumerable<Expression<T,BaseEntity>> instead of object , but this will not work when including ex: list of productItems
        // but can work with productItem 
    }
}
