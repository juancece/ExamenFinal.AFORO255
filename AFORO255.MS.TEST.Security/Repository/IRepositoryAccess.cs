using System.Collections.Generic;
using AFORO255.MS.TEST.Security.Model;

namespace AFORO255.MS.TEST.Security.Repository
{
    public interface IRepositoryAccess
    {
        IEnumerable<Access> GetAll();
    }
}