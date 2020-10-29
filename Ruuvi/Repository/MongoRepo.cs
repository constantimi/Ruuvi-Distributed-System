using System.Linq;
using Ruuvi.Settings;
using MongoDB.Driver;
using System.Collections.Generic;
using Ruuvi.Models;
using System.Threading.Tasks;
using System;
using MongoDB.Driver.Linq;
using MongoDB.Bson;
using System.Linq.Expressions;
using MongoDB.Bson.Serialization;

namespace Ruuvi.Repository
{
    public class MongoRepo<TDocument> : IMongoRepo<TDocument> where TDocument : IDocument
    {
        private readonly IMongoCollection<TDocument> _collection;

        public MongoRepo(IMongoDbSettings settings)
        {
            var client = new MongoClient(settings.ConnectionString);
            var database = client.GetDatabase(settings.DatabaseName);

            _collection = database.GetCollection<TDocument>(GetCollectionName(typeof(TDocument)));
        }

        private protected string GetCollectionName(Type type)
        {
            return ((BsonCollectionAttribute) type.GetCustomAttributes(
                typeof(BsonCollectionAttribute), true).FirstOrDefault())?.CollectionName;
        }

        public virtual IEnumerable<TDocument> GetAll()
        {
            return _collection.Find(doc => true).ToList();
        }

        public virtual Task<IEnumerable<TDocument>> GetAllAsync()
        {
            return Task.Run( () =>
            {
               return (IEnumerable<TDocument>) _collection.Find(doc => true).ToListAsync();
            });
        }

        public virtual IEnumerable<TDocument> GetLatest()
        {
            // CreatedAt should be changed to UpdatedAt
            return _collection.Find(doc => true).ToList().OrderByDescending(doc => doc.CreatedAt).GroupBy(doc=> new {doc.DeviceId},(key,group)=>group.First());
        }

        public IEnumerable<TDocument> GetAllCurrent()
        {
            return _collection.Find<TDocument>( doc => doc.CreatedAt > DateTime.UtcNow.AddDays(-1)).ToList();
        }

        public virtual TDocument GetObjectById(string id)
        {
            var objectId = new ObjectId(id);
            return _collection.Find<TDocument>(doc => doc.Id == objectId).FirstOrDefault();
        }

        public virtual Task<TDocument> GetObjectByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                 return _collection.Find<TDocument>(doc => doc.Id == objectId).FirstOrDefault();
            });
        }

        public virtual void CreateObject(TDocument document)
        {
            _collection.InsertOne(document);
        }

        public virtual Task CreateObjectAsync(TDocument document)
        {
            return Task.Run(() => _collection.InsertOneAsync(document));
        }

        public virtual void UpdateObject(string id, TDocument document)
        {
            var objectId = new ObjectId(id);
            _collection.ReplaceOne(doc => doc.Id == objectId, document);
        }

        public virtual Task UpdateObjectAsync(string id, TDocument document){
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                _collection.ReplaceOne(doc => doc.Id == objectId, document);
            });
        }

        public void RemoveObject(TDocument document)
        {
            _collection.DeleteOne(doc => doc.Id == document.Id);
        }

        public virtual Task RemoveObjectAsync(TDocument document)
        {
            return Task.Run(() =>
            {
                _collection.DeleteOne(doc => doc.Id == document.Id);
            });
        }

        public virtual void RemoveObjectById(string id)
        {
            var objectId = new ObjectId(id);
            _collection.DeleteOne(doc => doc.Id == objectId);
        }

        public virtual Task RemoveObjectByIdAsync(string id)
        {
            return Task.Run(() =>
            {
                var objectId = new ObjectId(id);
                _collection.DeleteOne(doc => doc.Id == objectId);
            });
        }

        public virtual IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression)
        {
           return _collection.Find(filterExpression).ToEnumerable();
        }

        public IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression)
        {
            return _collection.Find(filterExpression).Project(projectionExpression).ToEnumerable();
        }

        public IEnumerable<TDocument> Filter(string jsonQuery)
        {
            // https://medium.com/@samueleresca/querying-mongodb-using-net-core-d8484b790e7e

            var filter = BsonSerializer.Deserialize<BsonDocument>(jsonQuery);
            return _collection.Find<TDocument>(filter).ToList();
        }

    }
}