using System;
using System.Collections.Generic;
using System.Text;

namespace Blagajna.DataAccess
{
    public interface IRepository<T>
    {
        //CRUD
        List<T> GetAll();
        T GetById(int id);
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);

    }
}
 