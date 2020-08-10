using System.Collections.Generic;
using System.Linq;
using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository;

namespace AFORO255.MS.TEST.Security.Service
{
    class ServiceAccess : IServiceAccess
    {
        private readonly IRepositoryAccess _repositoryAccess;

        public ServiceAccess(IRepositoryAccess repositoryAccess)
        {
            _repositoryAccess = repositoryAccess;
        }

        public IEnumerable<Access> GetAll()
        {
            return _repositoryAccess.GetAll();
        }

        public bool Validate(string userName, string password)
        {
            var list = _repositoryAccess.GetAll();
            var access = list.FirstOrDefault(x => x.UserName == userName && x.Password == password);
            return access != null;
        }
    }
}