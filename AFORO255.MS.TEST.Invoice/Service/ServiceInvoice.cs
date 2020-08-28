using System.Collections.Generic;
using AFORO255.MS.TEST.Invoice.Repository;

namespace AFORO255.MS.TEST.Invoice.Service
{
    class ServiceInvoice : IServiceInvoice
    {
        private readonly IRepositoryInvoice _repositoryInvoice;

        public ServiceInvoice(IRepositoryInvoice repositoryInvoice)
        {
            _repositoryInvoice = repositoryInvoice;
        }

        public IEnumerable<Model.Invoice> GetAll()
        {
            return _repositoryInvoice.GetAll();
        }

        public bool Pay(int idInvoice)
        {
            return _repositoryInvoice.Pay(idInvoice);
        }
    }
}