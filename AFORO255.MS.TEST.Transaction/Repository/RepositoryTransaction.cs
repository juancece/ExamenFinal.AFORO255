using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IMongoDatabase _database;

        public RepositoryTransaction(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["cnmongo"]);
            _database = client.GetDatabase(configuration["mongodb"]);
        }

        public IMongoCollection<Model.Transaction> HistoryTransaction => _database.GetCollection<Model.Transaction>("Transaction");
    }
}