using MongoDB.Driver;

namespace CalculadoraIR.Infra.Repositories.Interfaces
{
    public interface IContext
    {
        MongoClient Client { get; }

        IMongoDatabase DataBase { get; }
    }
}
