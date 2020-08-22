using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Repository
{
    public interface IRepositoryTransaction
    {
        IMongoCollection<Model.Transaction> HistoryTransaction { get; }
    }
}