using MongoDB.Bson;
using MongoDB.Driver;
using RestApi.Model.Interface;
using RestApi.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RestApi.Repository.Repositories
{
    public class BaseMockRepository<TModel> : IBaseRepository<TModel>
           where TModel : IId<ObjectId>
    {
        private List<TModel> _list = new List<TModel>();

        public void Create(List<TModel> list)
        {
            throw new NotImplementedException();
        }

        public void Create(TModel newObject)
        {
            throw new NotImplementedException();
        }

        public DeleteResult Delete(Expression<Func<TModel, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public UpdateResult FindOneAndUpdate(Expression<Func<TModel, IEnumerable<MongoDBRef>>> dbRefExpression, ObjectId parentObjectId, MongoDBRef dbRef)
        {
            throw new NotImplementedException();
        }

        public UpdateResult FindOneAndUpdate<ParentObjectListItem>(Expression<Func<TModel, IEnumerable<ParentObjectListItem>>> parentArrayExpression, ObjectId parentObjectId, ParentObjectListItem item)
        {
            throw new NotImplementedException();
        }

        public IMongoCollection<TModel> GetCollection()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Retrieve(Expression<Func<TModel, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Retrieve(FilterDefinition<TModel> filter)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TModel> Retrieve(List<MongoDBRef> dbRefs)
        {
            throw new NotImplementedException();
        }

        public bool StartSession()
        {
            throw new NotImplementedException();
        }

        public UpdateResult Update(FilterDefinition<TModel> filter, UpdateDefinition<TModel> updateDefinition)
        {
            throw new NotImplementedException();
        }
    }
}