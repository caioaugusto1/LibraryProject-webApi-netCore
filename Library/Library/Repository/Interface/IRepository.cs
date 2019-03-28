using System.Collections.Generic;

namespace Library.Repository.Interface
{
    public interface IRepository<TEntity> where TEntity : class
    {
        List<TEntity> GetAll();

        TEntity GetById(string id);

        void Insert(TEntity obj);

        void Update(TEntity obj, string id);

        void RemoveById(string id);
    }
}
