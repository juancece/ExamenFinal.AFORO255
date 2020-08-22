using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public class RepositoryTransaction : IRepositoryTransaction
    {
        private readonly IMongoDatabase _database = null;

        public RepositoryTransaction(IConfiguration configuration)
        {
            var client = new MongoClient("mongo:cn");
            if (client != null)
            {
                _database = client.GetDatabase(configuration["mongo:database"]);
            }
        }

        public IMongoCollection<Model.Transaction> HistoryTransaction
        {
            get
            {
                return _database.GetCollection<Model.Transaction>("Transaction");
            }
        }
    }
}