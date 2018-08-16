using CalculadoraIR.Infra.Repositories.Connection;
using CalculadoraIR.Infra.Repositories.Interfaces;
using MongoDB.Driver;
using System.Configuration;

namespace CalculadoraIR.Infra.Repositories
{
    public sealed class CalculadoraIRContext : IContext
    {
        public static ContextFactory<CalculadoraIRContext> Factory => new ContextFactory<CalculadoraIRContext>();

        public MongoClient Client => _client;

        public IMongoDatabase DataBase => _database;

        public ContribuinteRepository Contribuinte { get; } = new ContribuinteRepository();

        private MongoClient _client;
        private IMongoDatabase _database;

        public CalculadoraIRContext()
        {
            _client = new MongoClient(ConfigurationManager.ConnectionStrings["conexaoMongoDB"].ConnectionString);
            _database = _client.GetDatabase(ConfigurationManager.AppSettings["DataBase"]);
        }
    }
}
