using System.Collections.Generic;
using AFORO255.MS.TEST.Pay.Model;

namespace AFORO255.MS.TEST.Pay.Service
{
    public interface IServicePay
    {
        Operation RegisterPay(Operation payOperation);
        IEnumerable<Operation> GetAll();
    }
}