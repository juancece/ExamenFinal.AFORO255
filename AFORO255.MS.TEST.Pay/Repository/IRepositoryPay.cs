using System.Collections.Generic;
using AFORO255.MS.TEST.Pay.Model;

namespace AFORO255.MS.TEST.Pay.Repository
{
    public interface IRepositoryPay
    {
        Operation RegisterPay(Operation payOperation);
        IEnumerable<Operation> GetAll();
    }
}