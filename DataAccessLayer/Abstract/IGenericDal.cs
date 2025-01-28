using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;
using EntityLayer.Concrete;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> where T : class, IEntity, new()
    {
        void Insert(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetListAll();
        T GetById(int id);
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
