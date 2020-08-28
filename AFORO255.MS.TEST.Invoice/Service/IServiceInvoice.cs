using System.Collections.Generic;

namespace AFORO255.MS.TEST.Invoice.Service
{
    public interface IServiceInvoice
    {
        IEnumerable<Model.Invoice> GetAll();
        bool Pay(int idInvoice);
    }
}