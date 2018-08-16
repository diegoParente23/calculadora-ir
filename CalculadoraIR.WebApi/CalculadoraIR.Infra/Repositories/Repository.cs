using CalculadoraIR.Infra.Repositories.Connection;
using CalculadoraIR.Shared;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace CalculadoraIR.Infra.Repositories
{
    public abstract class Repository<T>
        where T : Entity
    {
        protected MongoConnection Connection { get; private set; }

        protected IMongoCollection<T> Collection { get; private set; }

        public Repository()
        {
            Connection = MongoConnection.Connect();
            Collection = Connection.DataBase.GetCollection<T>(typeof(T).Name.ToLower());
        }

        protected virtual void Add(T entidade)
        {
            Collection.InsertOne(entidade);
        }

        protected virtual IEnumerable<T> GetAll()
        {
            return Collection.Find(new BsonDocument()).ToList();
        }

        protected virtual IEnumerable<T> Filter(Expression<Func<T, bool>> expression)
        {
            return Collection.Find(expression).ToList();
        }
    }
}
