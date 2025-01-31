using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace BusinessLayer.Abstract
{
    public interface IGenericService<T> where T : class, IEntity, new()
    {
        void TAdd(T t);
        void TDelete(T t);
        void TUpdate(T t);
        List<T> GetList();
        T GetById(int id);
    }
}
