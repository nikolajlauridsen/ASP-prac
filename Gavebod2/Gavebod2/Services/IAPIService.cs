using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Gavebod2.Services
{
    public interface IAPIService
    {
        Task<T> GetObject<T>(string endPoint, int id);
        Task<T> GetAll<T>(string endPoint);
        void InsertObject<T>(string endPoint, T obj);
        void UpdateObject<T>(string endPoint, T obj, int id);
        void DeleteObject(string endPoint, int id);
    }
}
