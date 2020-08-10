using System.Collections.Generic;
using System.Linq;
using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository.Data;

namespace AFORO255.MS.TEST.Security.Repository
{
    public class RepositoryAccess : IRepositoryAccess
    {
        private readonly IContextDatabase _contextDatabase;

        public RepositoryAccess(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Access> GetAll()
        {
            return _contextDatabase.Access.ToList();
        }
    }
}