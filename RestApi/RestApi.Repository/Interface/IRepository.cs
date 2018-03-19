using System;
using System.Collections.Generic;
using System.Text;

namespace RestApi.Repository.Interface
{
    interface IRepository<T>
    {
        T GetById(string id);
        IEnumerable<T> GetAll();
        void Insert(T model);
        void Update(string id, T model);
        bool Delete(string id);
    }
}
