using System.Collections.Generic;

namespace StoreWebAPI.Data.Repositories
{
    interface IRepository<T> where T: class
    {
        IEnumerable<T> GetAll();
        T GetById(int Id);
        void Create(T item);
        void Update(T item);
        void DelteById(int Id);
        void Save();
    }
}
