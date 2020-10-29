using Ruuvi.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Ruuvi.Repository
{
    public interface IMongoRepo<TDocument> where TDocument : IDocument
    {
        IEnumerable<TDocument> GetAll();

        Task<IEnumerable<TDocument>> GetAllAsync();

        IEnumerable<TDocument> GetLatest();

        IEnumerable<TDocument> GetAllCurrent();

        IEnumerable<TDocument> Filter (string jsonQuery);

        IEnumerable<TDocument> FilterBy(Expression<Func<TDocument, bool>> filterExpression);

        IEnumerable<TProjected> FilterBy<TProjected>(Expression<Func<TDocument, bool>> filterExpression, Expression<Func<TDocument, TProjected>> projectionExpression);
        
        TDocument GetObjectById(string id);

        Task<TDocument> GetObjectByIdAsync(string id);

        void CreateObject(TDocument document);

        Task CreateObjectAsync(TDocument document);

        void UpdateObject(string id, TDocument document);

        Task UpdateObjectAsync(string id, TDocument document);

        void RemoveObject(TDocument document);

        Task RemoveObjectAsync(TDocument document);

        void RemoveObjectById(string id);

        Task RemoveObjectByIdAsync(string id);

    }
}