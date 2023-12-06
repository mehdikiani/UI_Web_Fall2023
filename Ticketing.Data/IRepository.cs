using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ticketing.Core.Entities;

namespace Ticketing.Data
{
    public interface IRepository<T>
        where T :class // EntityBase
    {
        IQueryable<T> GetAll();
        int Insert(T entity);
        int Update(T entity);
        int Delete(T entity);
    }
}
