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

        public bool Pay(int idInvoice)
        {
            Model.Invoice invoice = _contextDatabase.Invoices.Find(idInvoice);
            invoice.State = 1;
            _contextDatabase.Invoices.Update(invoice);
            _contextDatabase.SaveChanges();
            return true;
        }
    }
}