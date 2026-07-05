using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWindDapperTrail
{
    public interface IManager<T>
    {
        bool Add(T item);
        bool Delete(long Id);
        bool Update(T item);
        List<T> GetAll();
        T GetById(long Id);

    }
}
