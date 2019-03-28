using Library.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Library.Repository
{
    public class RepositoryBase<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly IMongoCollection<TEntity> _mongoCollection;

        public RepositoryBase(IConfiguration configuration, string collectionName)
        {
            MongoClient client = new MongoClient(configuration.GetConnectionString("LibraryDB"));
            IMongoDatabase database = client.GetDatabase("Library");

            _mongoCollection = database.GetCollection<TEntity>(collectionName);
        }

        public List<TEntity> GetAll()
        {
            return _mongoCollection.Find<TEntity>(x => true).ToList();
        }

        public void Insert(TEntity obj)
        {
            _mongoCollection.InsertOne(obj);
        }

        public TEntity GetById(string id)
        {
            return _mongoCollection.Find<TEntity>(Builders<TEntity>.Filter.AnyEq("_id", ObjectId.Parse(id))).FirstOrDefault();
        }

        public void Update(TEntity obj, string id)
        {
            _mongoCollection.ReplaceOne(Builders<TEntity>.Filter.AnyEq("_id", ObjectId.Parse(id)), obj);
        }

        public void RemoveById(string id)
        {
            _mongoCollection.DeleteOne(Builders<TEntity>.Filter.AnyEq("_id", ObjectId.Parse(id)));
        }
    }
}
