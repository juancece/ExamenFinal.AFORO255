using System.Collections.Generic;
using AFORO255.MS.TEST.Pay.Model;
using AFORO255.MS.TEST.Pay.Repository;

namespace AFORO255.MS.TEST.Pay.Service
{
    public class ServicePay : IServicePay
    {
        private readonly IRepositoryPay _repositoryPay;

        public ServicePay(IRepositoryPay repositoryPay)
        {
            _repositoryPay = repositoryPay;
        }

        public Operation RegisterPay(Operation payOperation)
        {
            return _repositoryPay.RegisterPay(payOperation);
        }

        public IEnumerable<Operation> GetAll()
        {
            return _repositoryPay.GetAll();
        }
    }
}