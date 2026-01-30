using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trilha_Api_TIVIT.Infra.Interface
{
    public interface IRepository <T>
    {
         int Create(T entity);
        List<T> Read();
        T ReadById(int id);
        void Update(T entity);
        void Delete(int id);
        bool Exists(int id);
    }
}