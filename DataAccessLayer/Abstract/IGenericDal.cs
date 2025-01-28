using System;
using System.Collections.Generic;
using System.Linq;
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
        List<T> GetAll();
        T GetById(int id);
    }
}
