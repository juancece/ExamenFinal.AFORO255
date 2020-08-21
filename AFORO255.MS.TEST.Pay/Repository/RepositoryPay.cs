using System.Collections.Generic;
using System.Linq;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository.Data;

namespace AFORO255.MS.TEST.Pay.Repository
{
    class RepositoryPay : IRepositoryPay
    {
        private readonly IContextDatabase _contextDatabase;

        public RepositoryPay(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public Operation RegisterPay(Operation payOperation)
        {
            _contextDatabase.Operations.Add(payOperation);
            _contextDatabase.SaveChanges();
            return payOperation;
        }

        public IEnumerable<Operation> GetAll()
        {
            return _contextDatabase.Operations.ToList();
        }
    }
}