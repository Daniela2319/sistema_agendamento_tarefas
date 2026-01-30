using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace trilha_Api_TIVIT.Service.Interface
{
    public interface IService<T>
    {
        int Create(T model);
        List<T> Read();
        void Update(T model);
        void Delete(int id);
        T ReadById(int id);
        bool Exists(int id);
    }
}