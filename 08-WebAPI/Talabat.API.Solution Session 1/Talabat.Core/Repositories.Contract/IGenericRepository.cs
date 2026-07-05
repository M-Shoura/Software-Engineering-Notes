using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Talabat.Core.Entities;
using Talabat.Core.Entities.Products;

namespace Talabat.Core.Repositories.Contract
{
    public interface IGenericRepository<T> where T : BaseEntity
    {
        // Till now we need only "GetAll" and "GetById" .... because "create/update/delete" will be inside the MVC controller of the admin
        // dashboard ...

        Task<T?> GetAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
    }
}
