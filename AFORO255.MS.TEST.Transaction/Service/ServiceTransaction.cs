using System.Collections.Generic;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Transaction.DTO;
using AFORO255.MS.TEST.Transaction.Repository;
using MongoDB.Driver;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public class ServiceTransaction : IServiceTransaction
    {
        private readonly IRepositoryTransaction _repositoryTransaction;

        public ServiceTransaction(IRepositoryTransaction repositoryTransaction)
        {
            _repositoryTransaction = repositoryTransaction;
        }

        public async Task<IEnumerable<TransactionDto>> GetAll()
        {
            var data = await _repositoryTransaction.HistoryTransaction.Find(_ => true).ToListAsync();
            var response = new List<TransactionDto>();
            foreach (var item in data)
            {
                response.Add(new TransactionDto
                {
                    IdTransaction = item.IdTransaction,
                    IdInvoice = item.IdInvoice,
                    Amount = item.Amount,
                    Date = item.Date
                });
            }

            return response;
        }

        public async Task<bool> Add(Model.Transaction transaction)
        {
            await _repositoryTransaction.HistoryTransaction.InsertOneAsync(transaction);
            return true;
        }
    }
}