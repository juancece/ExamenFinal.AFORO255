using System.Collections.Generic;
using System.Threading.Tasks;
using AFORO255.MS.TEST.Transaction.DTO;

namespace AFORO255.MS.TEST.Transaction.Service
{
    public interface IServiceTransaction
    {
        Task<IEnumerable<TransactionDto>> GetAll();
        Task<bool> Add(Model.Transaction transaction);
    }
}