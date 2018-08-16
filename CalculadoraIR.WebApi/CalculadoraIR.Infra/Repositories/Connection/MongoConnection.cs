using MongoDB.Driver;
using System.Configuration;

namespace CalculadoraIR.Infra.Repositories.Connection
{
    public class MongoConnection
    {
        public MongoClient Client => _client;

        public IMongoDatabase DataBase => _database;

        private MongoClient _client;
        private IMongoDatabase _database;

        private MongoConnection()
        {
            _client = new MongoClient(ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString);
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["DataBase"]);
        }

        public static MongoConnection Connect()
            => new MongoConnection();
    }
}
