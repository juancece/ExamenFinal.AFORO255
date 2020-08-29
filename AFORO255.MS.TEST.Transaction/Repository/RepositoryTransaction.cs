using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IMongoDatabase _database = null;

        public RepositoryTransaction(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["mongo:cn"]);
            _database = client.GetDatabase(configuration["mongo:database"]);
        }

        public IMongoCollection<Model.Transaction> HistoryTransaction => _database.GetCollection<Model.Transaction>("Transaction");
    }
}