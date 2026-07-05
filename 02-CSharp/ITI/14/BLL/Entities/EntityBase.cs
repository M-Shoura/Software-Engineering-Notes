using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Entities
{
    // We have a baseEntity to put the common attributes and behaviours here , instead of putting them inside each class of entities
    public class EntityBase
    {
        public EntityState entityState { get; set; } = EntityState.Unchanged;
    }
}
