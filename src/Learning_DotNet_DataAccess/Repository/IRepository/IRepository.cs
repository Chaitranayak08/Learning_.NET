using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning_DotNet.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T:class
    {
        //T- Category (or any other Model)
        IEnumerable<T> GetAll(string? includeProperties = null);

        T Get(Expression<Func<T,bool>> filter, string? includeProperties = null);  //to retrieve one category

        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entity);

    }
}
