using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    /// <summary>
    /// Interface IController supports all other Controllers in BusineslogicLayer
    /// with all the needed CRUD functionality and extra methods.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IController<T>
    {
        void Create(T obj);
        T Get(int id);
        List<T> GetAll();
        void Update(T obj);
        void Delete(int id);
    }
}
