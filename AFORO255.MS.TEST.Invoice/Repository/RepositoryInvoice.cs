using System.Collections.Generic;
using System.Linq;
using AFORO255.MS.TEST.Invoice.Repository.Data;

namespace AFORO255.MS.TEST.Invoice.Repository
{
    public class RepositoryInvoice : IRepositoryInvoice
    {
        private readonly IContextDatabase _contextDatabase;

        public RepositoryInvoice(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Model.Invoice> GetAll()
        {
            return _contextDatabase.Invoices.ToList();
        }
    }
}