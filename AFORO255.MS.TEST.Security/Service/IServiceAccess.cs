using System.Collections.Generic;
using AFORO255.MS.TEST.Security.Model;

namespace AFORO255.MS.TEST.Security.Service
{
    public interface IServiceAccess
    {
        IEnumerable<Access> GetAll();
        bool Validate(string userName, string password);
    }
}