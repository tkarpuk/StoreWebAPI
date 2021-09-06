using System.Collections.Generic;
using System.Linq;

namespace StoreWebAPI.Data.Repositories
{
    public class RepositoryBase<T> : IRepository<T> where T: class
    {
        private readonly StoreDB db;
        public RepositoryBase(StoreDB db) => this.db = db;

        public void Create(T item)
        {
            db.Set<T>().Add(item);
        }

        public void DelteById(int Id)
        {
            T item = db.Set<T>().Find(Id);
            if (item != null)
                db.Set<T>().Remove(item);
        }

        public IEnumerable<T> GetAll()
        {
            return db.Set<T>().ToList();
        }

        public T GetById(int Id)
        {
            return db.Set<T>().Find(Id);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(T item)
        {
            db.Set<T>().Update(item);
        }
    }
}
